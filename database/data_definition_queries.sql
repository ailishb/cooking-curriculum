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
	CONSTRAINT `courseID`
		FOREIGN KEY (`courseID`)
		REFERENCES `course`(`courseID`)
		ON DELETE CASCADE
);