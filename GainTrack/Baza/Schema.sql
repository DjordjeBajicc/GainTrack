CREATE DATABASE  IF NOT EXISTS `gaintrack` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `gaintrack`;
-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: localhost    Database: gaintrack
-- ------------------------------------------------------
-- Server version	8.1.0

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__efmigrationshistory`
--

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
INSERT INTO `__efmigrationshistory` VALUES ('20241228092714_InitialMigration','8.0.2');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cardio_exercise`
--

DROP TABLE IF EXISTS `cardio_exercise`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cardio_exercise` (
  `Exercise_Id` int NOT NULL,
  PRIMARY KEY (`Exercise_Id`),
  CONSTRAINT `FK_Cardio_Exercise_Exercise_Exercise_Id` FOREIGN KEY (`Exercise_Id`) REFERENCES `exercise` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cardio_exercise`
--

LOCK TABLES `cardio_exercise` WRITE;
/*!40000 ALTER TABLE `cardio_exercise` DISABLE KEYS */;
INSERT INTO `cardio_exercise` VALUES (3);
/*!40000 ALTER TABLE `cardio_exercise` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `concrete_exercise_on_training`
--

DROP TABLE IF EXISTS `concrete_exercise_on_training`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `concrete_exercise_on_training` (
  `Date` date NOT NULL,
  `TrainingHasExerciseId` int NOT NULL,
  PRIMARY KEY (`Date`,`TrainingHasExerciseId`),
  KEY `IX_Concrete_Exercise_on_Training_TrainingHasExerciseId` (`TrainingHasExerciseId`),
  CONSTRAINT `FK_Concrete_Exercise_on_Training_Training_has_Exercise_Training~` FOREIGN KEY (`TrainingHasExerciseId`) REFERENCES `training_has_exercise` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `concrete_exercise_on_training`
--

LOCK TABLES `concrete_exercise_on_training` WRITE;
/*!40000 ALTER TABLE `concrete_exercise_on_training` DISABLE KEYS */;
INSERT INTO `concrete_exercise_on_training` VALUES ('2024-12-29',5),('2025-01-04',5),('2025-01-05',5),('2025-01-08',24),('2025-01-08',25),('2025-01-08',26),('2025-01-24',32),('2025-01-24',33),('2025-01-24',34),('2025-01-24',35);
/*!40000 ALTER TABLE `concrete_exercise_on_training` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `exercise`
--

DROP TABLE IF EXISTS `exercise`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `exercise` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Details` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Deleted` tinyint NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `exercise`
--

LOCK TABLES `exercise` WRITE;
/*!40000 ALTER TABLE `exercise` DISABLE KEYS */;
INSERT INTO `exercise` VALUES (1,'Deadlift',NULL,0),(2,'Pullup',NULL,0),(3,'Running',NULL,0),(4,'Squat',NULL,0),(5,'Leg Extensions',NULL,0),(6,'Lunges',NULL,0),(9,'Pushup',NULL,0),(10,'Lat Pull Downs',NULL,0),(11,'Barbell Rows',NULL,0);
/*!40000 ALTER TABLE `exercise` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `messurements`
--

DROP TABLE IF EXISTS `messurements`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `messurements` (
  `Name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`Name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `messurements`
--

LOCK TABLES `messurements` WRITE;
/*!40000 ALTER TABLE `messurements` DISABLE KEYS */;
INSERT INTO `messurements` VALUES ('Biceps'),('Butine'),('Listovi'),('Podlaktice'),('Prsa'),('Ramena'),('struk'),('Tezina'),('Vrat');
/*!40000 ALTER TABLE `messurements` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `series`
--

DROP TABLE IF EXISTS `series`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `series` (
  `SerialNumber` int NOT NULL,
  `ConcreteExerciseOnTrainingDate` date NOT NULL,
  `ConcreteExerciseOnTrainingTrainingHasExerciseId` int NOT NULL,
  `Weight` decimal(6,2) DEFAULT NULL,
  `Reps` int DEFAULT NULL,
  `Time` time(6) DEFAULT NULL,
  `Distance` decimal(8,2) DEFAULT NULL,
  PRIMARY KEY (`SerialNumber`,`ConcreteExerciseOnTrainingDate`,`ConcreteExerciseOnTrainingTrainingHasExerciseId`),
  KEY `IX_Series_ConcreteExerciseOnTrainingDate_ConcreteExerciseOnTrai~` (`ConcreteExerciseOnTrainingDate`,`ConcreteExerciseOnTrainingTrainingHasExerciseId`),
  CONSTRAINT `FK_Series_Concrete_Exercise_on_Training_ConcreteExerciseOnTrain~` FOREIGN KEY (`ConcreteExerciseOnTrainingDate`, `ConcreteExerciseOnTrainingTrainingHasExerciseId`) REFERENCES `concrete_exercise_on_training` (`Date`, `TrainingHasExerciseId`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `series`
--

LOCK TABLES `series` WRITE;
/*!40000 ALTER TABLE `series` DISABLE KEYS */;
INSERT INTO `series` VALUES (1,'2024-12-29',5,200.00,1,NULL,NULL),(1,'2025-01-04',5,150.00,10,NULL,NULL),(1,'2025-01-05',5,200.00,1,NULL,NULL),(1,'2025-01-08',24,200.00,2,NULL,NULL),(1,'2025-01-08',25,NULL,15,NULL,NULL),(1,'2025-01-08',26,110.00,12,NULL,NULL),(1,'2025-01-24',32,100.00,5,NULL,NULL),(1,'2025-01-24',33,NULL,15,NULL,NULL),(1,'2025-01-24',34,90.00,12,NULL,NULL),(1,'2025-01-24',35,110.00,12,NULL,NULL),(2,'2024-12-29',5,100.00,10,NULL,NULL),(2,'2025-01-04',5,150.00,8,NULL,NULL),(2,'2025-01-05',5,200.00,2,NULL,NULL),(2,'2025-01-08',24,150.00,10,NULL,NULL),(2,'2025-01-08',25,NULL,15,NULL,NULL),(2,'2025-01-08',26,100.00,10,NULL,NULL),(2,'2025-01-24',32,140.00,5,NULL,NULL),(2,'2025-01-24',33,NULL,15,NULL,NULL),(2,'2025-01-24',34,90.00,10,NULL,NULL),(2,'2025-01-24',35,110.00,10,NULL,NULL),(3,'2024-12-29',5,100.00,8,NULL,NULL),(3,'2025-01-04',5,140.00,12,NULL,NULL),(3,'2025-01-05',5,100.00,10,NULL,NULL),(3,'2025-01-24',32,180.00,1,NULL,NULL),(3,'2025-01-24',33,NULL,10,NULL,NULL),(3,'2025-01-24',34,70.00,12,NULL,NULL),(3,'2025-01-24',35,100.00,12,NULL,NULL),(4,'2025-01-24',32,200.00,1,NULL,NULL),(4,'2025-01-24',34,70.00,10,NULL,NULL),(4,'2025-01-24',35,100.00,10,NULL,NULL),(5,'2025-01-24',32,140.00,10,NULL,NULL);
/*!40000 ALTER TABLE `series` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `trainee`
--

DROP TABLE IF EXISTS `trainee`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `trainee` (
  `UserId` int NOT NULL,
  `TrainerId` int DEFAULT NULL,
  PRIMARY KEY (`UserId`),
  KEY `IX_Trainee_TrainerId` (`TrainerId`),
  CONSTRAINT `FK_Trainee_Trainer_TrainerId` FOREIGN KEY (`TrainerId`) REFERENCES `trainer` (`UserId`),
  CONSTRAINT `FK_Trainee_User_UserId` FOREIGN KEY (`UserId`) REFERENCES `user` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `trainee`
--

LOCK TABLES `trainee` WRITE;
/*!40000 ALTER TABLE `trainee` DISABLE KEYS */;
INSERT INTO `trainee` VALUES (2,NULL),(3,1),(4,1),(5,1),(7,1),(8,1),(9,1),(10,1);
/*!40000 ALTER TABLE `trainee` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `trainer`
--

DROP TABLE IF EXISTS `trainer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `trainer` (
  `UserId` int NOT NULL,
  PRIMARY KEY (`UserId`),
  CONSTRAINT `FK_Trainer_User_UserId` FOREIGN KEY (`UserId`) REFERENCES `user` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `trainer`
--

LOCK TABLES `trainer` WRITE;
/*!40000 ALTER TABLE `trainer` DISABLE KEYS */;
INSERT INTO `trainer` VALUES (1);
/*!40000 ALTER TABLE `trainer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `training`
--

DROP TABLE IF EXISTS `training`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `training` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Trainee_Id` int NOT NULL,
  `Deleted` tinyint NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Training_Trainee_Id` (`Trainee_Id`),
  CONSTRAINT `FK_Training_Trainee_Trainee_Id` FOREIGN KEY (`Trainee_Id`) REFERENCES `trainee` (`UserId`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `training`
--

LOCK TABLES `training` WRITE;
/*!40000 ALTER TABLE `training` DISABLE KEYS */;
INSERT INTO `training` VALUES (4,'aa',2,1),(5,'dsd',4,1),(6,'eee',4,1),(7,'tt',4,1),(8,'ttss',4,0),(9,'a',2,1),(10,'test',2,0),(11,'proba',5,0),(13,'proba',2,1),(14,'Leđa',3,0),(15,'Trcanje',3,1),(16,'Back',2,0);
/*!40000 ALTER TABLE `training` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `training_has_exercise`
--

DROP TABLE IF EXISTS `training_has_exercise`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `training_has_exercise` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Training_Id` int NOT NULL,
  `Exercise_Id` int NOT NULL,
  `Deleted` tinyint NOT NULL,
  `Number_Of_Series` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Training_has_Exercise_Exercise_Id` (`Exercise_Id`),
  KEY `IX_Training_has_Exercise_Training_Id` (`Training_Id`),
  CONSTRAINT `FK_Training_has_Exercise_Exercise_Exercise_Id` FOREIGN KEY (`Exercise_Id`) REFERENCES `exercise` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_Training_has_Exercise_Training_Training_Id` FOREIGN KEY (`Training_Id`) REFERENCES `training` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=36 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `training_has_exercise`
--

LOCK TABLES `training_has_exercise` WRITE;
/*!40000 ALTER TABLE `training_has_exercise` DISABLE KEYS */;
INSERT INTO `training_has_exercise` VALUES (5,4,1,0,3),(6,5,1,0,2),(7,6,2,0,6),(8,7,3,0,1),(9,8,1,0,1),(10,8,2,0,1),(11,9,1,0,3),(12,9,2,0,3),(13,9,3,0,3),(14,10,4,0,2),(15,10,5,0,5),(16,10,6,0,5),(17,11,1,0,4),(18,11,2,0,5),(19,11,5,0,1),(24,13,1,0,2),(25,13,2,0,2),(26,13,11,0,2),(27,14,1,0,4),(28,14,2,0,5),(29,14,11,0,5),(30,14,10,0,5),(31,15,3,0,1),(32,16,1,0,5),(33,16,2,0,3),(34,16,10,0,4),(35,16,11,0,4);
/*!40000 ALTER TABLE `training_has_exercise` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Firstname` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Lastname` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Username` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Password` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Theme` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Language` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Deleted` tinyint NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Username_UNIQUE` (`Username`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,'Djordje','Bajic','trener','trener','GreenTheme','English',0),(2,'Djordje','Bajic','vjezbac','vjezbac','GreenTheme','English',0),(3,'Marko','Markovic','marko','marko','Dark','English',0),(4,'Petar','Petrovic','petar','petar','Dark','English',0),(5,'Ognjen','Bajic','ognjen','ognjen','Dark','English',1),(7,'Milan','Milanovic','milan','milan','Dark','English',1),(8,'mirko','mirkovic','mirko','mirko','Dark','English',0),(9,'nikola','nikolic','nikola','nikola','Dark','English',0),(10,'Uros','Urosevic','uros','uros','Dark','English',0);
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_has_messurement`
--

DROP TABLE IF EXISTS `user_has_messurement`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user_has_messurement` (
  `TraineeId` int NOT NULL,
  `MessurementName` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Date` date NOT NULL,
  `Value` decimal(6,2) NOT NULL,
  PRIMARY KEY (`TraineeId`,`MessurementName`,`Date`),
  KEY `IX_User_Has_Messurement_MessurementName` (`MessurementName`),
  CONSTRAINT `FK_User_Has_Messurement_Messurements_MessurementName` FOREIGN KEY (`MessurementName`) REFERENCES `messurements` (`Name`),
  CONSTRAINT `FK_User_Has_Messurement_Trainee_TraineeId` FOREIGN KEY (`TraineeId`) REFERENCES `trainee` (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_has_messurement`
--

LOCK TABLES `user_has_messurement` WRITE;
/*!40000 ALTER TABLE `user_has_messurement` DISABLE KEYS */;
INSERT INTO `user_has_messurement` VALUES (2,'Biceps','2024-11-15',42.50),(2,'Biceps','2024-11-30',44.00),(2,'Biceps','2024-12-28',43.00),(2,'Podlaktice','2024-12-28',33.00),(2,'Ramena','2025-01-08',130.00),(2,'Tezina','2024-12-28',89.00);
/*!40000 ALTER TABLE `user_has_messurement` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `weight_exercise`
--

DROP TABLE IF EXISTS `weight_exercise`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `weight_exercise` (
  `Exercise_Id` int NOT NULL,
  PRIMARY KEY (`Exercise_Id`),
  CONSTRAINT `FK_Weight_Exercise_Exercise_Exercise_Id` FOREIGN KEY (`Exercise_Id`) REFERENCES `exercise` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `weight_exercise`
--

LOCK TABLES `weight_exercise` WRITE;
/*!40000 ALTER TABLE `weight_exercise` DISABLE KEYS */;
INSERT INTO `weight_exercise` VALUES (1),(2),(4),(5),(6),(9),(10),(11);
/*!40000 ALTER TABLE `weight_exercise` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-01-28  9:28:51
