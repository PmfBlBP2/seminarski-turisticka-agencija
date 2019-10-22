CREATE DATABASE  IF NOT EXISTS `turisticka_agencija` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `turisticka_agencija`;
-- MySQL dump 10.13  Distrib 5.7.25, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: turisticka_agencija
-- ------------------------------------------------------
-- Server version	5.5.5-10.1.36-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `destinacija`
--

DROP TABLE IF EXISTS `destinacija`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `destinacija` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `DrzavaId` int(11) NOT NULL,
  `Grad` varchar(1024) NOT NULL,
  `Opis` varchar(10000) DEFAULT NULL,
  `Slika` varchar(10000) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `DestinacijaId_UNIQUE` (`Id`),
  KEY `fk_destinacija_drzava1_idx` (`DrzavaId`),
  CONSTRAINT `fk_destinacija_drzava1` FOREIGN KEY (`DrzavaId`) REFERENCES `drzava` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `destinacija`
--
-- ORDER BY:  `Id`

LOCK TABLES `destinacija` WRITE;
/*!40000 ALTER TABLE `destinacija` DISABLE KEYS */;
INSERT INTO `destinacija` (`Id`, `DrzavaId`, `Grad`, `Opis`, `Slika`) VALUES (1,6,'Beč','Beč leži u sjeveroistočnom dijelu Austrije, između Alpa i Karpata, gdje je Dunav probio svoj put prema moru kroz planine.','https://storage.radiosarajevo.ba/image/426112/1180x732/bec-panorama-grada-15.jpg'),(2,8,'Pariz','Pariz je prestonica i najveći grad Francuske. Nalazi se na severu Francuske na reci Seni.','http://www.travelland.rs/content_pictures/resized/hit--pariz-avionom-4-noci-2019-941.jpg'),(3,1,'Banja Luka','Smješten na obali Vrbasa, vrlo fin. Sve preporuke.','http://www.banjaluka-tourism.banjaluka-turizam.com/images/Magical-City-No.3.jpg');
/*!40000 ALTER TABLE `destinacija` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `drzava`
--

DROP TABLE IF EXISTS `drzava`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `drzava` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Naziv` varchar(1024) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `drzava`
--
-- ORDER BY:  `Id`

LOCK TABLES `drzava` WRITE;
/*!40000 ALTER TABLE `drzava` DISABLE KEYS */;
INSERT INTO `drzava` (`Id`, `Naziv`) VALUES (1,'Bosna i Hercegovina'),(2,'Srbija'),(3,'Hrvatska'),(4,'Crna Gora'),(5,'Švajcarska'),(6,'Austrija'),(7,'Španija'),(8,'Francuska'),(9,'Rusija'),(10,'Kina'),(11,'Japan'),(12,'Sjedinjene Američke Države'),(13,'Velika Britanija');
/*!40000 ALTER TABLE `drzava` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `kompanija`
--

DROP TABLE IF EXISTS `kompanija`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `kompanija` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Naziv` varchar(1024) NOT NULL,
  `Grad` varchar(1024) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `kompanija`
--
-- ORDER BY:  `Id`

LOCK TABLES `kompanija` WRITE;
/*!40000 ALTER TABLE `kompanija` DISABLE KEYS */;
INSERT INTO `kompanija` (`Id`, `Naziv`, `Grad`) VALUES (1,'Lasta','Beograd'),(2,'Golub','Kotor Varoš'),(3,'Tempoturist','Teslić'),(4,'Neobas','Banja Luka'),(5,'AirSerbia','Beograd'),(6,'WizzAir','Budimpešta'),(7,'RyanAir','Dablin');
/*!40000 ALTER TABLE `kompanija` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `korisnik`
--

DROP TABLE IF EXISTS `korisnik`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `korisnik` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Ime` varchar(1024) NOT NULL,
  `Prezime` varchar(1024) NOT NULL,
  `DatumRodjenja` date NOT NULL,
  `Email` varchar(1024) DEFAULT NULL,
  `BrojTelefona` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id_UNIQUE` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `korisnik`
--
-- ORDER BY:  `Id`

LOCK TABLES `korisnik` WRITE;
/*!40000 ALTER TABLE `korisnik` DISABLE KEYS */;
INSERT INTO `korisnik` (`Id`, `Ime`, `Prezime`, `DatumRodjenja`, `Email`, `BrojTelefona`) VALUES (1,'Aleksandar','Toprek','1995-07-29','aleksandartoprek@gmail.com','+387 66 219 745'),(2,'Tanja','Gromilic','1996-05-08','tanjagromilic@gmail.com','+387 65 311 051'),(3,'Nikolina','Čolić','1995-09-08','nikolinacolic@gmail.com',NULL),(4,'Đorđe','Simeunčević','1995-05-19','djordjes@gmail.com',NULL),(6,'Pero','Peric','1993-01-25','perop@gmail.com','+387 66 123 456');
/*!40000 ALTER TABLE `korisnik` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ponuda`
--

DROP TABLE IF EXISTS `ponuda`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ponuda` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `SmjestajId` int(11) NOT NULL,
  `DestinacijaId` int(11) NOT NULL,
  `PrevozId` int(11) NOT NULL,
  `Naziv` varchar(1024) NOT NULL,
  `Opis` varchar(5000) DEFAULT NULL,
  `DatumKreiranja` date NOT NULL,
  `Pocetak` date NOT NULL,
  `Kraj` date NOT NULL,
  `Cijena` decimal(10,2) NOT NULL,
  `BrojMijesta` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `IdPutovanja_UNIQUE` (`Id`),
  KEY `fk_ponuda_smjestaj1_idx` (`SmjestajId`),
  KEY `fk_ponuda_destinacija1_idx` (`DestinacijaId`),
  KEY `fk_ponuda_prevoz1_idx` (`PrevozId`),
  CONSTRAINT `fk_ponuda_destinacija1` FOREIGN KEY (`DestinacijaId`) REFERENCES `destinacija` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ponuda_prevoz1` FOREIGN KEY (`PrevozId`) REFERENCES `prevoz` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ponuda_smjestaj1` FOREIGN KEY (`SmjestajId`) REFERENCES `smjestaj` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ponuda`
--
-- ORDER BY:  `Id`

LOCK TABLES `ponuda` WRITE;
/*!40000 ALTER TABLE `ponuda` DISABLE KEYS */;
INSERT INTO `ponuda` (`Id`, `SmjestajId`, `DestinacijaId`, `PrevozId`, `Naziv`, `Opis`, `DatumKreiranja`, `Pocetak`, `Kraj`, `Cijena`, `BrojMijesta`) VALUES (1,1,2,3,'Nova godina u Parizu','Pariz je grad koji se razvijao u koncentričnim krugovima, grad sa mnoštvom kulturnih spomenika i galerija koje čuvaju neprocenjivo umetničko blago, grad u kome se meša duh užurbanosti i opuštenosti. Elegantan grad na reci Seni, pored koje se slikari okupljaju kako bi pokušali da na platno prenesu svoja osećanja. Trg Konkord predstavlja najsavršenije urbanističko rešenje na svetu  i dokaz funkcionalnosti prestonice Francuske jer su u jednoj ravni sagradjene Ajfelova kula, Trijumfalna kapija i katedrala Notr Dam. Uživajmo u božanstvenoj arhitekturi i duhu minulih vekova koji se kombinuju sa najnovijim svetskim trendovima. Dozvolimo sebi malo romantike i mnogo dobrog provoda i pozitivne energije sa milionima ljudi na ulicama!','2019-10-08','2019-12-25','2020-01-05',1350.00,50),(2,2,1,2,'Advent u Beču','Božićni ili adventski sajmovi u srednjoj Europi imaju dugu tradiciju. Austrijski su posebno omiljeni, a najpoznatiji među njima svakako je bečki adventski sajam. Riječ je o pravoj maloj zemlji čuda, koja svake godine privuče više od tri milijuna posjetitelja.','2019-10-08','2019-12-20','2019-12-24',430.00,30),(3,3,3,1,'Vikend u Banjoj Luci',NULL,'2019-10-15','2019-10-25','2019-10-27',55.50,50),(5,3,2,3,'Test Ponuda',NULL,'2019-10-17','2019-10-19','2019-10-24',240.00,50);
/*!40000 ALTER TABLE `ponuda` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `prevoz`
--

DROP TABLE IF EXISTS `prevoz`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `prevoz` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `KompanijaId` int(11) NOT NULL,
  `TipPrevozaId` int(11) NOT NULL,
  `Opis` varchar(10000) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_prevoz_kompanija1_idx` (`KompanijaId`),
  KEY `fk_prevoz_tip_prevoza1_idx` (`TipPrevozaId`),
  CONSTRAINT `fk_prevoz_kompanija1` FOREIGN KEY (`KompanijaId`) REFERENCES `kompanija` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_prevoz_tip_prevoza1` FOREIGN KEY (`TipPrevozaId`) REFERENCES `tip_prevoza` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `prevoz`
--
-- ORDER BY:  `Id`

LOCK TABLES `prevoz` WRITE;
/*!40000 ALTER TABLE `prevoz` DISABLE KEYS */;
INSERT INTO `prevoz` (`Id`, `KompanijaId`, `TipPrevozaId`, `Opis`) VALUES (1,1,1,'Visokoturistički autobus'),(2,2,1,'Autobus na sprat'),(3,5,2,'Airbus A-320'),(4,6,2,'Charter let');
/*!40000 ALTER TABLE `prevoz` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rezervacija`
--

DROP TABLE IF EXISTS `rezervacija`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `rezervacija` (
  `PonudaId` int(11) NOT NULL,
  `KorisnikId` int(11) NOT NULL,
  `DatumRezervacije` datetime DEFAULT NULL,
  `Iznos` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`PonudaId`,`KorisnikId`),
  KEY `fk_rezervacija_ponuda1_idx` (`PonudaId`),
  KEY `fk_rezervacija_korisnik1_idx` (`KorisnikId`),
  CONSTRAINT `fk_rezervacija_korisnik1` FOREIGN KEY (`KorisnikId`) REFERENCES `korisnik` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_rezervacija_ponuda1` FOREIGN KEY (`PonudaId`) REFERENCES `ponuda` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rezervacija`
--
-- ORDER BY:  `PonudaId`,`KorisnikId`

LOCK TABLES `rezervacija` WRITE;
/*!40000 ALTER TABLE `rezervacija` DISABLE KEYS */;
INSERT INTO `rezervacija` (`PonudaId`, `KorisnikId`, `DatumRezervacije`, `Iznos`) VALUES (1,1,'2019-10-17 00:00:00',1350.00),(2,2,'2019-10-15 00:00:00',430.00),(3,1,'2019-10-17 20:44:04',55.50),(3,2,'2019-10-17 20:44:16',55.50),(5,1,'2019-10-17 19:25:02',240.00),(5,3,'2019-10-17 19:19:39',240.00),(5,4,'2019-10-17 20:09:48',240.00),(5,6,'2019-10-17 19:15:38',240.00);
/*!40000 ALTER TABLE `rezervacija` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `smjestaj`
--

DROP TABLE IF EXISTS `smjestaj`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `smjestaj` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `DestinacijaId` int(11) NOT NULL,
  `Naziv` varchar(1024) NOT NULL,
  `Opis` varchar(10000) DEFAULT NULL,
  `Adresa` varchar(1024) DEFAULT NULL,
  `Slika` varchar(3000) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_smjestaj_destinacija1_idx` (`DestinacijaId`),
  CONSTRAINT `fk_smjestaj_destinacija1` FOREIGN KEY (`DestinacijaId`) REFERENCES `destinacija` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `smjestaj`
--
-- ORDER BY:  `Id`

LOCK TABLES `smjestaj` WRITE;
/*!40000 ALTER TABLE `smjestaj` DISABLE KEYS */;
INSERT INTO `smjestaj` (`Id`, `DestinacijaId`, `Naziv`, `Opis`, `Adresa`, `Slika`) VALUES (1,2,'Four Seasons Hotel George V','Hotel obuhvata vrhunske spa tretmane, restorane nagrađene Mišlenovim zvezdicama i privatne terase sa veličanstvenim pogledom na Pariz.','31 Avenue George V','https://q-cf.bstatic.com/images/hotel/max1024x768/137/137519245.jpg'),(2,1,'Sofie Apartments','Apartmani Sofie se nalaze na 5 minuta vožnje od Katedrale Sv. Stefana i na 5 minuta hoda od Bulevara Ring.','Kegelgasse 20','https://q-cf.bstatic.com/images/hotel/max1024x768/946/94619515.jpg'),(3,3,'Hotel Palace','Hotel Palace smješten je na glavnom trgu u zgradi koja je uvrštena u nacionalnu baštinu.','Kralja Petra I. Karađorđevića 60','https://r-cf.bstatic.com/images/hotel/max1024x768/188/18805752.jpg');
/*!40000 ALTER TABLE `smjestaj` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tip_prevoza`
--

DROP TABLE IF EXISTS `tip_prevoza`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tip_prevoza` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Naziv` varchar(1024) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tip_prevoza`
--
-- ORDER BY:  `Id`

LOCK TABLES `tip_prevoza` WRITE;
/*!40000 ALTER TABLE `tip_prevoza` DISABLE KEYS */;
INSERT INTO `tip_prevoza` (`Id`, `Naziv`) VALUES (1,'Autobus'),(2,'Avion'),(3,'Voz'),(4,'Brod');
/*!40000 ALTER TABLE `tip_prevoza` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'turisticka_agencija'
--

--
-- Dumping routines for database 'turisticka_agencija'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-10-22 17:32:51
