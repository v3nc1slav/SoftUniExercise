import { getData, createPlayer, deletePlayer } from './data.js';
import { loadCanvas } from './loadCanvas.js';
import el from './dom.js';

window.addEventListener('load', async () => {

    const input = {
        addPlayer() {return document.getElementById("addPlayer")},
        addName() {return document.getElementById("addName").valie},
        players() {return document.getElementById("players")},
    }

    getPlayers()

    async function getPlayers() {
        const data = await getData();
        data.forEach(p => {

            const playBtn = el('button', 'Play');
            const deleteBtn = el('button', 'Delete');
            
            const div = el("div",[
                `Name: ${p.name}\n  Money: ${p.money}\n Bullets:${p.bullets}`,
                playBtn, 
                deleteBtn
            ])

            input.players().appendChild(div)

            deleteBtn.addEventListener("click", () => {
                deletePlayers(p.objectId);
            })

            playBtn.addEventListener("click", () => {
                loadCanvas(p);
            })

        });
    }

    async function deletePlayers(id) {
        try {
            await deletePlayer(id);
            getPlayers()
            
        } catch (error) {
            console.error(error)
        }
    }

})