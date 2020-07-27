import { getFormEntity, clearForm } from './formDataFuncs.js';
import { sendRequest } from './requestGen.js';

async function commonPartials() {
  this.partials = {
    header: await this.load('./templates/common/header.hbs'),
    footer: await this.load('./templates/common/footer.hbs'),
  };
  this.loggedIn = sessionStorage.getItem('loggedIn') || false;
  this.username = sessionStorage.getItem('username');
}

async function homeViewHandler() {
  await commonPartials.call(this);
  this.partial('./templates/home/home.hbs');
}

async function aboutViewHandler() {
  await commonPartials.call(this);
  this.partial('./templates/about/about.hbs');
}

async function loginViewHandler() {
  await commonPartials.call(this);
  this.partials.loginForm = await this.load('./templates/login/loginForm.hbs');

  await this.partial('./templates/login/loginPage.hbs');

  let form = document.getElementById('login-form');

  form.addEventListener('submit', (e) => {
    e.preventDefault();
    let data = getFormEntity(form);
    if (!Object.values(data).includes('')) {

      firebase.auth().signInWithEmailAndPassword(data.username, data.password)
        .then(async (response) => {
          firebase.auth().currentUser.getIdToken()
            .then(async token => {
              sessionStorage.setItem('token', token); //Token refresher func can be added since token expires on 1 hour
              sessionStorage.setItem('loggedIn', true);
              sessionStorage.setItem('username', response.user.email);
              sessionStorage.setItem('uid', response.user.uid);
              let data = await (await sendRequest(`https://softuni-tests-bfd33.firebaseio.com/userInfo/${response.user.uid}.json`,
                token,
                'GET'
              )).json();

              sessionStorage.setItem('hasNoTeam', data.hasNoTeam);
              sessionStorage.setItem('team', data.team);
            })

          displayMessage('Logged in!', 'infoBox');
          clearForm(form);
          this.redirect(['#/home']);
        })
        .catch(function (error) {
          var errorCode = error.code;
          var errorMessage = error.message;
          displayMessage(`${errorCode}: ${errorMessage}`, 'errorBox');
        });
    } else {
      displayMessage('There is an empty field!', 'errorBox');
    }
  });

}

async function registerViewHandler() {
  await commonPartials.call(this);
  this.partials.registerForm = await this.load('./templates/register/registerForm.hbs');

  await this.partial('./templates/register/registerPage.hbs');

  let form = document.getElementById('register-form');

  form.addEventListener('submit', (e) => {
    e.preventDefault();

    let data = getFormEntity(form);

    if (!Object.values(data).includes('') && data.password === data.repeatPassword) {
      firebase.auth().createUserWithEmailAndPassword(data.username, data.password)
        .then((response) => {
          displayMessage('User successfully created!', 'infoBox');
          clearForm(form);
          firebase.auth().currentUser.getIdToken()
            .then(token => {
              sendRequest(`https://softuni-tests-bfd33.firebaseio.com/userInfo/${response.user.uid}.json`,
                token,
                'PUT',
                JSON.stringify({
                  hasNoTeam: true,
                  team: 'none'
                })
              );
            })
          this.redirect(['#/login']);
        })
        .catch(function (error) {
          var errorCode = error.code;
          var errorMessage = error.message;
          displayMessage(`${errorCode}: ${errorMessage}`, 'errorBox');
        });
    } else {
      displayMessage("Passwords don't match or there is an empty field!", 'errorBox');
    }
  });
}

function logoutHandler() {
  firebase.auth().signOut().then(() => {
    sessionStorage.clear();
    displayMessage('Logged out!', 'infoBox');
    this.redirect(['#/login']);
  })
    .catch(function (error) {
      var errorCode = error.code;
      var errorMessage = error.message;
      displayMessage(`${errorCode}: ${errorMessage}`, 'errorBox');
    });
}

async function catalogViewHandler() {
  await commonPartials.call(this);
  this.partials.team = await this.load('./templates/catalog/team.hbs');

  let data = await getTeamsFromDB();
  if (data !== null) {
    for (const id in data) {
      data[id]._id = id;
    }
    this.teams = Object.values(data);
  }

  this.hasNoTeam = (sessionStorage.getItem('hasNoTeam') == 'true' && sessionStorage.getItem('team') === 'none');

  this.partial('./templates/catalog/teamCatalog.hbs');
}

async function createViewHandler() {
  await commonPartials.call(this);
  this.partials.createForm = await this.load('./templates/create/createForm.hbs');
  await this.partial('./templates/create/createPage.hbs');

  let form = document.getElementById('create-form');

  form.addEventListener('submit', async (e) => {
    e.preventDefault();
    let data = getFormEntity(form);
    data.members = [{ username: sessionStorage.getItem('username') }];
    data.author = sessionStorage.getItem('uid');
    if (!Object.values(data).includes('')) {
      let responseTeamKey = await (await sendRequest('https://softuni-tests-bfd33.firebaseio.com/teams.json',
        sessionStorage.getItem('token'),
        'POST',
        JSON.stringify(data)
      )).json();


      await sendRequest(`https://softuni-tests-bfd33.firebaseio.com/userInfo/${sessionStorage.getItem('uid')}.json`,
        sessionStorage.getItem('token'),
        'PUT',
        JSON.stringify({ hasNoTeam: false, team: responseTeamKey.name })
      );
      sessionStorage.setItem('hasNoTeam', false);
      sessionStorage.setItem('team', responseTeamKey.name);
      displayMessage(`Team ${data.name} created!`, 'infoBox');
      clearForm(form);
      this.redirect(['#/catalog']);
    }
  })
}

async function getTeamsFromDB() {
  let response = await sendRequest('https://softuni-tests-bfd33.firebaseio.com/teams.json', sessionStorage.getItem('token'), 'GET');
  if (response.status !== 200) {
    throw (response);
  }
  let data = await response.json();
  return data;
}

function displayMessage(message, boxId) {
  let box = document.getElementById(boxId);
  box.style.display = 'block';
  box.textContent = message;
  setTimeout(() => box.style.display = 'none', 2000);
}

async function detailsViewHandler() {
  await commonPartials.call(this);
  this.partials.teamControls = await this.load('./templates/catalog/teamControls.hbs');
  this.partials.teamMember = await this.load('./templates/catalog/teamMember.hbs');
  let team = await (await sendRequest(`https://softuni-tests-bfd33.firebaseio.com/teams/-${document.URL.split(':-')[1]}.json`,
    sessionStorage.getItem('token'),
    'GET'
  )).json();
  this.name = team.name;
  this.comment = team.comment;
  this.members = team.members;
  this.teamId = `-${document.URL.split(':-')[1]}`;
  sessionStorage.setItem('teamId', this.teamId);
  team.author === sessionStorage.getItem('uid') ? this.isAuthor = true : this.isAuthor = false;


  let user = await (await sendRequest(`https://softuni-tests-bfd33.firebaseio.com/userInfo/${sessionStorage.getItem('uid')}.json`,
    sessionStorage.getItem('token'),
    'GET'
  )).json();


  (user.team !== 'none' && user.team === this.teamId) ? this.isOnTeam = true : this.isOnTeam = false;

  this.partial('./templates/catalog/details.hbs');
}

async function leaveTeamHandler() {
  let team = await (await sendRequest(`https://softuni-tests-bfd33.firebaseio.com/teams/${sessionStorage.getItem('teamId')}.json`,
    sessionStorage.getItem('token'),
    'GET'
  )).json();
  team.members === undefined ? team.members = [] : team.members = team.members;
  await sendRequest(`https://softuni-tests-bfd33.firebaseio.com/teams/${sessionStorage.getItem('teamId')}.json`,
    sessionStorage.getItem('token'),
    'PATCH',
    JSON.stringify({ members: team.members.filter(member => member.username !== sessionStorage.getItem('username')) })
  );

  await sendRequest(`https://softuni-tests-bfd33.firebaseio.com/userInfo/${sessionStorage.getItem('uid')}.json`,
    sessionStorage.getItem('token'),
    'PATCH',
    JSON.stringify({
      hasNoTeam: true,
      team: 'none'
    }));
  sessionStorage.setItem('hasNoTeam', true);
  sessionStorage.setItem('team', 'none');
  displayMessage('You left the team!', 'infoBox');
  this.redirect(['#/catalog']);
}

async function joinViewHandler() {
  if (sessionStorage.getItem('team') !== 'none') {
    displayMessage('You are already in other team!', 'errorBox');
    this.redirect([`#/catalog/:${sessionStorage.getItem('teamId')}`]);
  } else {
    let team = await (await sendRequest(`https://softuni-tests-bfd33.firebaseio.com/teams/${sessionStorage.getItem('teamId')}.json`,
      sessionStorage.getItem('token'),
      'GET'
    )).json();
    team.members === undefined ? team.members = [] : team.members = team.members;
    team.members.push({ username: sessionStorage.getItem('username') });

    await sendRequest(`https://softuni-tests-bfd33.firebaseio.com/teams/${sessionStorage.getItem('teamId')}.json`,
      sessionStorage.getItem('token'),
      'PATCH',
      JSON.stringify({ members: team.members })
    );

    await sendRequest(`https://softuni-tests-bfd33.firebaseio.com/userInfo/${sessionStorage.getItem('uid')}.json`,
      sessionStorage.getItem('token'),
      'PATCH',
      JSON.stringify({
        hasNoTeam: false,
        team: sessionStorage.getItem('teamId')
      }));
    sessionStorage.setItem('hasNoTeam', false);
    sessionStorage.setItem('team', sessionStorage.getItem('teamId'));
    displayMessage('You joined the team!', 'infoBox');
    this.redirect([`#/catalog/:${sessionStorage.getItem('teamId')}`]);
  }
}

async function editViewHandler() {
  await commonPartials.call(this);
  this.partials.editForm = await this.load('./templates/edit/editForm.hbs');
  this.teamId = sessionStorage.getItem('teamId');
  let team = await (await sendRequest(`https://softuni-tests-bfd33.firebaseio.com/teams/${sessionStorage.getItem('teamId')}.json`,
    sessionStorage.getItem('token'),
    'GET'
  )).json();
  this.name = team.name;
  this.comment = team.comment;
  await this.partial('./templates/edit/editPage.hbs');

  let form = document.getElementById('edit-form');
  form.addEventListener('submit', async (e) => {
    e.preventDefault();
    let data = getFormEntity(form);

    await sendRequest(`https://softuni-tests-bfd33.firebaseio.com/teams/${sessionStorage.getItem('teamId')}.json`,
      sessionStorage.getItem('token'),
      'PATCH',
      JSON.stringify(data)
    );
    displayMessage('Team updated with the new information!', 'infoBox');
    this.redirect([`#/catalog/:${sessionStorage.getItem('teamId')}`]);
  });
}

var app = Sammy('#main', function () {
  // include a plugin
  this.use('Handlebars', 'hbs');

  // define a 'route'
  this.get('#/', homeViewHandler);
  this.get('#/home', homeViewHandler);
  this.get('#/about', aboutViewHandler);
  this.get('#/login', loginViewHandler);
  this.get('#/register', registerViewHandler);
  this.get('#/logout', logoutHandler);
  this.get('#/catalog', catalogViewHandler);
  this.get('#/create', createViewHandler);
  this.get(/\#\/catalog\/\:\-.{19}/, detailsViewHandler);
  this.get(/\#\/join\/\:\-.{19}/, joinViewHandler);
  this.get(/\#\/edit\/\:\-.{19}/, editViewHandler);
  this.get('#/leave', leaveTeamHandler);
  this.post('#/register', () => false);
  this.post('#/login', () => false);
  this.post('#/create', () => false);
  this.post(/\#\/edit\/\:\-.{19}/, () => false);
  //TODO - add #create team functionality;
});

// start the application
app.run('#/');