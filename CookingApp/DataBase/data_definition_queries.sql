DROP TABLE `courseTags`;
DROP TABLE `courseRecipes`;
DROP TABLE `userCourseEnrollment`;
DROP TABLE `recipeCompletion`;
DROP TABLE `recipeSteps`;
DROP TABLE `recipeTags`;
DROP TABLE `recipeRatings`;
DROP TABLE `users`;
DROP TABLE `recipe`;
DROP TABLE `course`;


CREATE TABLE `course` (
	`courseID` int(10) NOT NULL AUTO_INCREMENT PRIMARY KEY,
	`name` varchar(80) NOT NULL,
	`description` varchar(280) NOT NULL,
	`author` varchar(40) NOT NULL
);

CREATE TABLE `courseTags` (
	`courseTagID` int(10) NOT NULL AUTO_INCREMENT PRIMARY KEY,
	`courseID` int(10) NOT NULL,
	`tagType` varchar(80) NOT NULL,
	`tagDescription` varchar(80) NOT NULL,
	CONSTRAINT `courseID_courseTags_fk`
		FOREIGN KEY (`courseID`)
		REFERENCES `course`(`courseID`)
		ON DELETE CASCADE
);

CREATE TABLE `recipe` (
	`recipeID` int(10) NOT NULL AUTO_INCREMENT PRIMARY KEY,
	`difficultyLevel` int(2) NOT NULL,
	`name` varchar(80) NOT NULL,
	`description` varchar(280) NOT NULL,
	`author` varchar(40) NOT NULL
);

CREATE TABLE `courseRecipes` (
	`courseRecipeID` int(10) NOT NULL AUTO_INCREMENT PRIMARY KEY,
	`courseID` int(10) NOT NULL,
	`recipeID` int(10) NOT NULL,
	`order` int(10) NOT NULL,
	CONSTRAINT `courseID_courseRecipes_fk`
		FOREIGN KEY (`courseID`)
		REFERENCES `course`(`courseID`)
		ON DELETE CASCADE,
	CONSTRAINT `recipeID_courseRecipes_fk`
		FOREIGN KEY (`recipeID`)
		REFERENCES `recipe`(`recipeID`)
		ON DELETE CASCADE
);

CREATE TABLE `users` (
	`userID` int(10) NOT NULL AUTO_INCREMENT PRIMARY KEY,
	`username` varchar(80) NOT NULL,
	`status` varchar(40) NOT NULL
);

CREATE TABLE `userCourseEnrollment` (
	`enrollmentID` int(10) NOT NULL AUTO_INCREMENT PRIMARY KEY,
	`userID` int(10) NOT NULL,
	`courseID` int(10) NOT NULL,
	`status` varchar(40) NOT NULL,
	CONSTRAINT `courseID_userCourseEnrollment_fk`
		FOREIGN KEY (`courseID`)
		REFERENCES `course`(`courseID`)
		ON DELETE CASCADE,
	CONSTRAINT `userID_userCourseEnrollment_fk`
		FOREIGN KEY (`userID`)
		REFERENCES `users`(`userID`)
		ON DELETE CASCADE
);

CREATE TABLE `recipeTags` (
	`recipeTagID` int(10) NOT NULL AUTO_INCREMENT PRIMARY KEY,
	`recipeID` int(10) NOT NULL,
	`tagType` varchar(80) NOT NULL,
	`tagDescription` varchar(80) NOT NULL,
	CONSTRAINT `recipeID_recipeTags_fk`
		FOREIGN KEY (`recipeID`)
		REFERENCES `recipe`(`recipeID`)
		ON DELETE CASCADE
);

CREATE TABLE `recipeSteps` (
	`recipeStepID` int(10) NOT NULL AUTO_INCREMENT PRIMARY KEY,
	`recipeID` int(10) NOT NULL,
	`name` varchar(80) NOT NULL,
	`instructions` varchar(280) NOT NULL,
	CONSTRAINT `recipeID_recipeSteps_fk`
		FOREIGN KEY (`recipeID`)
		REFERENCES `recipe`(`recipeID`)
		ON DELETE CASCADE
);

CREATE TABLE `recipeRatings` (
	`recipeRatingID` int(10) NOT NULL AUTO_INCREMENT PRIMARY KEY,
	`recipeID` int(10) NOT NULL,
	`userID` int(10) NOT NULL,
	`dateEntered` date NOT NULL,
	`difficultyRating` int(10) NOT NULL,
	`minutesToCook` int(10) NOT NULL,
	`tastiness` int(10) NOT NULL,
	`reviewText` varchar(280) NOT NULL,
	CONSTRAINT `recipeID_recipeRatings_fk`
		FOREIGN KEY (`recipeID`)
		REFERENCES `recipe`(`recipeID`)
		ON DELETE CASCADE,
	CONSTRAINT `userID_recipeRatings_fk`
		FOREIGN KEY (`userID`)
		REFERENCES `users`(`userID`)
		ON DELETE CASCADE
);

CREATE TABLE `recipeCompletion` (
	`recipeCompletionID` int(10) NOT NULL AUTO_INCREMENT PRIMARY KEY,
	`recipeID` int(10) NOT NULL,
	`userID` int(10) NOT NULL,
	`dateStatus` date NOT NULL,
	`recipeStatus` varchar(40) NOT NULL,
	CONSTRAINT `recipeID_recipeCompletion_fk`
		FOREIGN KEY (`recipeID`)
		REFERENCES `recipe`(`recipeID`)
		ON DELETE CASCADE,
	CONSTRAINT `userID_recipeCompletion_fk`
		FOREIGN KEY (`userID`)
		REFERENCES `users`(`userID`)
		ON DELETE CASCADE
);

CREATE TABLE `recipeIngredients` (
	`ingredientID` int(10) NOT NULL AUTO_INCREMENT PRIMARY KEY,
	`recipeID` int(10) NOT NULL,
	`description` varchar(40) NOT NULL,
	`unit` varchar(40) NOT NULL,
	`amount` int(10) NOT NULL,
	CONSTRAINT `recipeID_recipeIngredients_fk`
		FOREIGN KEY (`recipeID`)
		REFERENCES `recipe`(`recipeID`)
		ON DELETE CASCADE
);

ALTER TABLE recipe
  ADD COLUMN img_url varchar(80) NOT NULL DEFAULT "~/images/defaultrecipe.jpg";
 
ALTER TABLE recipe
  ADD COLUMN img_url varchar(80) NOT NULL DEFAULT "~/images/defaultrecipe.jpg";

ALTER TABLE recipeSteps
  ADD COLUMN img_url varchar(80) NOT NULL DEFAULT "~/images/defaultrecipestep.jpg";
  
ALTER TABLE recipeSteps
  ADD COLUMN stepOrder varchar(80) NOT NULL DEFAULT 0;
  
 ALTER TABLE recipe
  ADD COLUMN timeToCookMins int NOT NULL DEFAULT 30;
