INSERT INTO `course` (`name`, `description`, `author`) 
	VALUES	('Intro To Cooking', 'This course will teach you the very basics of cooking food for humans.', 'Bobbly Flay');
    
INSERT INTO `courseTags` (
	`courseID`,
	`tagType`,
	`tagDescription`)
	VALUES (1, 'Difficulty', 'Easy'), (1, 'Cuisine', 'All'), (1, 'Healthiness', 'Low');
    
INSERT INTO `recipe` (
	`difficultyLevel`,
	`name`,
	`description`,
	`author`)
	VALUES (1, 'Scrambled Eggs', 'Mmmm, delicious scrambled eggs. Basically, an egg, but scrambled.', 'Bobbly Flay');
    
INSERT INTO `courseRecipes` (
	`courseID`,
	`recipeID`,
	`order`)
	VALUES (1, 1, 1);
    
INSERT INTO `users` (
	`username`,
	`status`)
	VALUES ('ElonMusk22', 'Active');

INSERT INTO `userCourseEnrollment` (
	`userID`,
	`courseID`,
	`status`)
	VALUES (1, 1, 'Enrolled');
    
INSERT INTO `recipeTags` (
	`recipeID`,
	`tagType`,
	`tagDescription`)
	VALUES (1, 'Complexity', 'Low');

INSERT INTO `recipeSteps` (
	`recipeID`,
	`name`,
	`instructions`)
	VALUES (1, 'Break eggs', 'Break eggs into pan, add salt, and mix well'),
	(1, 'Turn on heat', 'Turn the heat on to low and mix steadily until eggs resemble cottage cheese'),
	(1, 'Serve and eat', 'Put eggs on plate, and eat.');

INSERT INTO `recipeRatings` (
	`recipeID`,
	`userID`,
	`dateEntered`,
	`difficultyRating`,
	`minutesToCook`,
	`tastiness`,
	`reviewText`)
	VALUES (1, 1, '2018-11-20', 10, 12, 5, 'Eggs are wierd.');
    
INSERT INTO `recipeCompletion` (
	`recipeID`,
	`userID`,
	`dateStatus`,
	`recipeStatus`)
	VALUES (1, 1, '2018-11-20', 'Completed');
	
SELECT * FROM course;
SELECT * FROM courseRecipes;
SELECT * FROM courseTags;
SELECT * FROM recipe;
SELECT * FROM recipeCompletion;
SELECT * FROM recipeRatings;
SELECT * FROM recipeSteps;
SELECT * FROM recipeTags;
SELECT * FROM userCourseEnrollment;
SELECT * FROM users;