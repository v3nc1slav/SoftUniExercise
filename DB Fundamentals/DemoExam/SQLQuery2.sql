USE Bitbucket

-- 02
INSERT INTO Files(Name,	Size,ParentId,CommitId) VALUES 
('Trade.idk',	2598.0,	1,	1),
('menu.net',	9238.31,	2,	2),
('Administrate.soshy',	1246.93,	3,	3),
('Controller.php',	7353.15,	4,	4),
('Find.java',	9957.86,	5,	5),
('Controller.json',	14034.87,	3,	6),
('Operate.xix',	7662.92,	7,	7)


INSERT INTO Issues(Title,IssueStatus,RepositoryId,AssigneeId) VALUES 
('Critical Problem with HomeController.cs file',	'open',	1,	4),
('Typo fix in Judge.html',	'open',	4,	3),
('Implement documentation for UsersService.cs',	'closed',	8,	2),
('Unreachable code in Index.cs',	'open',	9,	8)

--03
UPDATE Issues
SET IssueStatus = 'closed'
WHERE AssigneeId = 6

--04



--05
SELECT c.ID, c.MESSAGE, c.RepositoryId, c.ContributorId
FROM Commits AS c
ORDER BY c.ID, c.MESSAGE, c.RepositoryId, c.ContributorId

--06
SELECT ID, NAME, SIZE
FROM files
WHERE SIZE >= 1000 AND NAME LIKE '%html'
ORDER BY size DESC, ID, NAME

--07
SELECT i.Id, u.USERNAME +' : '+ i.Title AS IssueAssignee
FROM Issues AS i
JOIN USERS AS u ON u.ID = i.AssigneeId
ORDER BY i.Id DESC, IssueAssignee

--08
SELECT Id,	Name,	CONCAT (Size,'KB') AS Size
FROM files AS f
WHERE PARENTID != ID
ORDER BY ID, NAME, SIZE DESC

--09
SELECT *
FROM (
SELECT R.ID, U.NAME, COUNT(*) AS Commits
FROM commits AS C
JOIN Repositories AS R ON C.ContributorId = R.ID
JOIN Users AS U ON C.REPOSITORYID = U.ID
GROUP BY R.ID,  R.NAME) AS MY
ORDER BY MY.ID, MY.NAME


--10
SELECT *
FROM(
SELECT U.Username, AVG(SIZE) AS SIZE
FROM FILES AS F
JOIN commits AS C ON C.ID = F.COMMITID
JOIN Users AS U ON C.ContributorId = U.ID
GROUP BY U.USERNAME) AS MY
ORDER BY MY.Size DESC , MY.Username

GO

--11
CREATE FUNCTION udf_UserTotalCommits(@username VARCHAR (MAX)) 
RETURNS INT
AS
BEGIN
RETURN(
SELECT COUNT(*)
FROM USERS AS U
JOIN commits AS C ON C.ContributorId = U.ID
WHERE u.USERNAME = @username)
END;

GO

--12
CREATE PROC usp_FindByExtension(@extension VARCHAR (MAX)) 
AS
BEGIN
SELECT Id,	Name,	CONCAT (Size,'KB') AS Size
FROM FILES
WHERE RIGHT(NAME, LEN(@extension) )= @extension
END;

