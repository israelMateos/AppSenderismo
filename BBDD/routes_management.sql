-- MySQL dump 10.13  Distrib 8.0.31, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: routes_management
-- ------------------------------------------------------
-- Server version	8.0.31

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
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `email` varchar(255) NOT NULL,
  `password` varchar(30) NOT NULL,
  `name` varchar(255) NOT NULL,
  `surname` varchar(255) NOT NULL,
  `phone` char(9) NOT NULL,
  `dni` char(9) NOT NULL,
  `last_access` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`email`),
  UNIQUE KEY `dni` (`dni`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES ('usuario1@gmail.com','pass1','Juan','Perez','123456789','12345678A','2023-01-15 12:54:44'),('usuario10@gmail.com','pass10','Angel','Perez','012345678','01234567J','2023-01-15 12:54:44'),('usuario11@gmail.com','pass11','Manuel','Sanchez','123456789','12345678K','2023-01-15 12:54:44'),('usuario12@gmail.com','pass12','Sara','Garcia','234567890','23456789L','2023-01-15 12:54:44'),('usuario13@gmail.com','pass13','Andres','Martinez','345678901','34567890M','2023-01-15 12:54:44'),('usuario14@gmail.com','pass14','Julia','Gonzalez','456789012','45678901N','2023-01-15 12:54:44'),('usuario15@gmail.com','pass15','Diana','Rodriguez','567890123','56789020O','2023-01-15 12:54:44'),('usuario16@gmail.com','pass16','Sofia','Sanchez','678901234','67890123P','2023-01-15 12:54:44'),('usuario17@gmail.com','pass17','Adrian','Garcia','789012345','78901234Q','2023-01-15 12:54:44'),('usuario18@gmail.com','pass18','Alejandro','Martinez','890123456','89012345R','2023-01-15 12:54:44'),('usuario19@gmail.com','pass19','Valeria','Gonzalez','901234567','90123456S','2023-01-15 12:54:44'),('usuario2@gmail.com','pass2','Maria','Garcia','234567890','23456789B','2023-01-15 12:54:44'),('usuario20@gmail.com','pass20','Camila','Perez','012345678','01234567T','2023-01-15 12:54:44'),('usuario3@gmail.com','pass3','Pedro','Martinez','345678901','34567890C','2023-01-15 12:54:44'),('usuario4@gmail.com','pass4','Ana','Gonzalez','456789012','45678901D','2023-01-15 12:54:44'),('usuario5@gmail.com','pass5','Luis','Rodriguez','567890123','56789020E','2023-01-15 12:54:44'),('usuario6@gmail.com','pass6','Lucia','Sanchez','678901234','67890123F','2023-01-15 12:54:44'),('usuario7@gmail.com','pass7','Carlos','Garcia','789012345','78901234G','2023-01-15 12:54:44'),('usuario8@gmail.com','pass8','Isabel','Martinez','890123456','89012345H','2023-01-15 12:54:44'),('usuario9@gmail.com','pass9','Diego','Gonzalez','901234567','90123456I','2023-01-15 12:54:44');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

DROP TABLE IF EXISTS `takes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;

DROP TABLE IF EXISTS `route`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;

DROP TABLE IF EXISTS `guide`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;

--
-- Table structure for table `guide`
--

DROP TABLE IF EXISTS `guide`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `guide` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  `surname` varchar(255) NOT NULL,
  `phone` char(9) NOT NULL,
  `email` varchar(255) NOT NULL,
  `languages` varchar(255) NOT NULL,
  `availability_restrictions` varchar(255) NOT NULL,
  `score` int NOT NULL,
  `profile_image` blob,
  PRIMARY KEY (`id`),
  UNIQUE KEY `email` (`email`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `guide`
--

LOCK TABLES `guide` WRITE;
/*!40000 ALTER TABLE `guide` DISABLE KEYS */;
INSERT INTO `guide` VALUES (1,'Sophia','Johnson','987654321','guia1@gmail.com','Español, Inglés','Lunes, Miércoles y Viernes a partir de las 14:00 horas',8,_binary 'imagen1'),(2,'Jacob','Williams','876543219','guia2@gmail.com','Español, Italiano','Martes y Jueves a partir de las 09:00 horas',9,_binary 'imagen2'),(3,'Mia','Jones','765432198','guia3@gmail.com','Español, Alemán','Lunes, Miércoles y Viernes a partir de las 16:00 horas',7,_binary 'imagen3'),(4,'Ethan','Brown','654321987','guia4@gmail.com','Español, Francés','Martes y Jueves a partir de las 11:00 horas',8,_binary 'imagen4'),(5,'Emma','Miller','543219876','guia5@gmail.com','Español, Chino','Lunes, Miércoles y Viernes a partir de las 10:00 horas',9,_binary 'imagen5'),(6,'Madison','Moore','432198765','guia6@gmail.com','Español, Portugués','Martes y Jueves a partir de las 14:00 horas',8,_binary 'imagen6'),(7,'Aiden','Taylor','321987654','guia7@gmail.com','Español, Ruso','Lunes, Miércoles y Viernes a partir de las 09:00 horas',9,_binary 'imagen7'),(8,'Abigail','Anderson','219876543','guia8@gmail.com','Español, Japonés','Martes y Jueves a partir de las 16:00 horas',7,_binary 'imagen8'),(9,'Joshua','Thomas','198765432','guia9@gmail.com','Español, Coreano','Lunes, Miércoles y Viernes a partir de las 11:00 horas',8,_binary 'imagen9'),(10,'Emily','Jackson','987654321','guia10@gmail.com','Español, Árabe','Martes y Jueves a partir de las 10:00 horas',9,_binary 'imagen10'),(11,'Madison','Moore','876543219','guia11@gmail.com','Español, Inglés','Lunes, Miércoles y Viernes a partir de las 14:00 horas',8,_binary 'imagen11'),(12,'Aiden','Taylor','765432198','guia12@gmail.com','Español, Italiano','Martes y Jueves a partir de las 09:00 horas',9,_binary 'imagen12'),(13,'Abigail','Anderson','654321987','guia13@gmail.com','Español, Alemán','Lunes, Miércoles y Viernes a partir de las 16:00 horas',7,_binary 'imagen13'),(14,'Joshua','Thomas','543219876','guia14@gmail.com','Español, Francés','Martes y Jueves a partir de las 11:00 horas',8,_binary 'imagen14'),(15,'Emily','Jackson','432198765','guia15@gmail.com','Español, Chino','Lunes, Miércoles y Viernes a partir de las 10:00 horas',9,_binary 'imagen15'),(16,'Madison','Moore','321987654','guia16@gmail.com','Español, Portugués','Martes y Jueves a partir de las 14:00 horas',8,_binary 'imagen16'),(17,'Aiden','Taylor','219876543','guia17@gmail.com','Español, Ruso','Lunes, Miércoles y Viernes a partir de las 09:00 horas',9,_binary 'imagen17'),(18,'Abigail','Anderson','198765432','guia18@gmail.com','Español, Japonés','Martes y Jueves a partir de las 16:00 horas',7,_binary 'imagen18'),(19,'Joshua','Thomas','987654321','guia19@gmail.com','Español, Coreano','Lunes, Miércoles y Viernes a partir de las 11:00 horas',8,_binary 'imagen19'),(20,'Emily','Jackson','765544331','guia20@gmail.com','Español,Coreano','Lunes, Miércoles y Viernes a partir de las 11:00 horas',8,_binary 'imagen20');
/*!40000 ALTER TABLE `guide` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

--
-- Table structure for table `route`
--

CREATE TABLE `route` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  `provinces` varchar(255) NOT NULL,
  `date_time` datetime NOT NULL,
  `origin` varchar(255) NOT NULL,
  `destination` varchar(255) NOT NULL,
  `difficulty` enum('Difícil','Medio','Bajo') NOT NULL,
  `estimated_duration` int NOT NULL,
  `access_way` text NOT NULL,
  `exit_way` text NOT NULL,
  `needed_material` text NOT NULL,
  `eat_in_route` tinyint(1) NOT NULL,
  `guide_id` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `name` (`name`),
  KEY `route_guide_id_fk` (`guide_id`),
  CONSTRAINT `route_guide_id_fk` FOREIGN KEY (`guide_id`) REFERENCES `guide` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `route`
--

LOCK TABLES `route` WRITE;
/*!40000 ALTER TABLE `route` DISABLE KEYS */;
INSERT INTO `route` VALUES (1,'Ruta de los volcanes','Granada,Almería','2023-01-10 09:00:00','Granada','Almería','Difícil',10,'Desde Granada se subirá al volcán por un camino de montaña.','Se bajará por otro camino diferente.','Mochila, agua, comida, botas de senderismo.',0,1),(2,'Ruta de los castillos','Córdoba,Jaén','2023-01-15 09:00:00','Córdoba','Jaén','Medio',8,'Desde Córdoba se visitará el castillo por un camino asfaltado.','Se regresará por el mismo camino.','Mochila, agua, comida, zapatillas cómodas.',0,2),(3,'Ruta de los lagos','Huelva,Sevilla','2023-01-20 09:00:00','Huelva','Sevilla','Bajo',6,'Desde Huelva se llegará al lago por un camino llano.','Se regresará por el mismo camino.','Mochila, agua, comida, ropa cómoda.',1,3),(4,'Ruta de las aldeas','Málaga,Cádiz','2023-02-25 09:00:00','Málaga','Cádiz','Medio',8,'Desde Málaga se visitará la aldea por un camino de montaña.','Se regresará por el mismo camino.','Mochila, agua, comida, botas de senderismo.',0,4),(5,'Ruta de los pueblos','Cádiz,Huelva','2023-01-30 09:00:00','Cádiz','Huelva','Bajo',6,'Desde Cádiz se llegará al pueblo por un camino llano.','Se regresará por el mismo camino.','Mochila, agua, comida, ropa cómoda.',1,5),(6,'Ruta de los molinos','Sevilla,Málaga','2024-03-05 09:00:00','Sevilla','Málaga','Medio',8,'Desde Sevilla se visitará el molino por un camino de montaña.','Se regresará por el mismo camino.','Mochila, agua, comida, botas de senderismo.',0,5),(7,'Ruta de los parajes','Almería,Granada','2024-02-10 09:00:00','Almería','Granada','Difícil',10,'Desde Almería se subirá al paraje por un camino de montaña.','Se bajará por otro camino diferente.','Mochila, agua, comida, botas de senderismo.',0,6),(8,'Ruta de los ríos','Jaén,Córdoba','2024-03-15 09:00:00','Jaén','Córdoba','Bajo',6,'Desde Jaén se llegará al río por un camino llano.','Se regresará por el mismo camino.','Mochila, agua, comida, ropa cómoda.',1,7),(9,'Ruta de las ruinas','Granada,Almería','2024-04-20 09:00:00','Granada','Almería','Medio',8,'Desde Granada se visitará la ruina por un camino de montaña.','Se regresará por el mismo camino.','Mochila, agua, comida, botas de senderismo.',0,8),(10,'Ruta de los parajes 2','Córdoba,Jaén','2024-05-25 09:00:00','Córdoba','Jaén','Difícil',10,'Desde Córdoba se subirá al paraje por un camino de montaña.','Se bajará por otro camino diferente.','Mochila, agua, comida, botas de senderismo.',0,9);
/*!40000 ALTER TABLE `route` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

--
-- Table structure for table `traveller`
--

DROP TABLE IF EXISTS `traveller`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `traveller` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL,
  `surname` varchar(255) DEFAULT NULL,
  `phone` char(9) DEFAULT NULL,
  `age` int DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `traveller`
--

LOCK TABLES `traveller` WRITE;
/*!40000 ALTER TABLE `traveller` DISABLE KEYS */;
INSERT INTO `traveller` VALUES (1,'John','Doe','612345678',25),(2,'Jane','Doe','601234567',30),(3,'Mike','Smith','712345678',35),(4,'Samantha','Johnson','701234567',40),(5,'Emily','Williams','612345679',45),(6,'Jacob','Jones','701234568',50),(7,'Michael','Brown','612345670',55),(8,'Emily','Miller','701234561',60),(9,'Jacob','Davis','612345662',65),(10,'Michael','Garcia','701234563',70),(11,'Emily','Rodriguez','612345665',75),(12,'Jacob','Martinez','701234566',78),(13,'Michael','Anderson','612345667',79),(14,'Emily','Taylor','701234568',80),(15,'Jacob','Thomas','712345669',75),(16,'Michael','Hernandez','701234560',70),(17,'Emily','Moore','612345661',65),(18,'Jacob','Martin','701234562',60);
/*!40000 ALTER TABLE `traveller` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

--
-- Table structure for table `takes`
--

DROP TABLE IF EXISTS `takes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `takes` (
  `traveller_id` int NOT NULL,
  `route_id` int NOT NULL,
  PRIMARY KEY (`traveller_id`,`route_id`),
  KEY `route_id` (`route_id`),
  CONSTRAINT `takes_ibfk_1` FOREIGN KEY (`traveller_id`) REFERENCES `traveller` (`id`),
  CONSTRAINT `takes_ibfk_2` FOREIGN KEY (`route_id`) REFERENCES `route` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `takes`
--

LOCK TABLES `takes` WRITE;
/*!40000 ALTER TABLE `takes` DISABLE KEYS */;
INSERT INTO `takes` VALUES (1,1),(2,1),(3,1),(4,1),(5,2),(6,2),(7,2),(8,2),(1,3),(2,3),(9,3),(10,3),(3,4),(4,4),(5,4),(6,4),(7,5),(8,5),(9,5),(10,5),(1,6),(2,6),(3,6),(4,6),(5,7),(6,7),(7,7),(8,7),(1,8),(2,8),(9,8),(10,8),(3,9),(4,9),(5,9),(6,9),(7,10),(8,10),(9,10),(10,10);
/*!40000 ALTER TABLE `takes` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

-- Dump completed on 2023-01-18 18:58:46
