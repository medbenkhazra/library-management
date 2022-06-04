-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Jun 04, 2022 at 12:03 PM
-- Server version: 5.7.31
-- PHP Version: 7.3.21

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `bibliotheque`
--

-- --------------------------------------------------------

--
-- Table structure for table `cd`
--

DROP TABLE IF EXISTS `cd`;
CREATE TABLE IF NOT EXISTS `cd` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `titre` varchar(20) NOT NULL,
  `auteur` varchar(20) NOT NULL,
  `numeroOuvrage` int(11) NOT NULL,
  `quantite` varchar(20) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `cd`
--

INSERT INTO `cd` (`id`, `titre`, `auteur`, `numeroOuvrage`, `quantite`) VALUES
(1, 'hdfsh', 'medCD', 99, '13'),
(5, 'gsfg', 'cd2', 7, '76');

-- --------------------------------------------------------

--
-- Table structure for table `client`
--

DROP TABLE IF EXISTS `client`;
CREATE TABLE IF NOT EXISTS `client` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(20) NOT NULL,
  `cin` varchar(20) NOT NULL,
  `email` varchar(20) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `client`
--

INSERT INTO `client` (`id`, `nom`, `cin`, `email`) VALUES
(7, 'mohammed', 'EER7869', 'shgg@gmail.com'),
(2, 'oussamaBen', 'zeg543', 'oussama@gmail.com'),
(6, 'achraf', 'ERIYG753', 'achraf@gmail.com'),
(8, 'badr', 'ehteh55', 'badr@gmail.com'),
(9, 'asmae', 'AZERTY789', 'asmae@gmail.com'),
(10, 'test', 'hrsh', 'test@gmail.com');

-- --------------------------------------------------------

--
-- Table structure for table `emprunts`
--

DROP TABLE IF EXISTS `emprunts`;
CREATE TABLE IF NOT EXISTS `emprunts` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `dateEmp` date NOT NULL,
  `dateRetou` date NOT NULL,
  `etat` varchar(20) NOT NULL,
  `idLivre` int(11) DEFAULT NULL,
  `idCd` int(11) DEFAULT NULL,
  `idPeriodique` int(11) DEFAULT NULL,
  `idClient` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fkComp1` (`idLivre`),
  KEY `fkComp2` (`idCd`),
  KEY `fkComp3` (`idPeriodique`),
  KEY `fkComp4` (`idClient`)
) ENGINE=MyISAM AUTO_INCREMENT=46 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `emprunts`
--

INSERT INTO `emprunts` (`id`, `dateEmp`, `dateRetou`, `etat`, `idLivre`, `idCd`, `idPeriodique`, `idClient`) VALUES
(27, '2022-01-01', '2022-01-05', 'non emprunté', NULL, NULL, 1, 7),
(26, '2022-01-01', '2022-01-04', 'non emprunté', NULL, NULL, 4, 7),
(25, '2022-01-02', '2022-01-02', 'emprunté', NULL, 5, NULL, NULL),
(24, '2022-01-02', '2022-01-02', 'emprunté', 18, NULL, NULL, 2),
(23, '2022-01-02', '2022-01-02', 'emprunté', NULL, NULL, 1, 7),
(22, '2022-01-04', '2022-01-05', 'emprunté', NULL, NULL, 1, NULL),
(28, '2022-01-01', '2022-01-05', 'emprunté', NULL, NULL, 4, 7),
(29, '2022-01-01', '2022-01-06', 'emprunté', 13, NULL, NULL, 7),
(30, '2021-12-29', '2021-12-31', 'emprunté', 13, NULL, NULL, 2),
(31, '2021-12-29', '2021-11-01', 'emprunté', 18, NULL, NULL, 2),
(32, '2021-12-29', '2021-11-01', 'emprunté', 14, NULL, NULL, 2),
(33, '2022-01-03', '2021-12-31', 'emprunté', 13, NULL, NULL, 8),
(34, '2022-01-03', '2021-12-01', 'emprunté', 18, NULL, NULL, 8),
(35, '2022-01-03', '2021-12-02', 'emprunté', 14, NULL, NULL, 8),
(36, '2022-01-03', '2021-12-02', 'emprunté', NULL, NULL, 4, 9),
(37, '2022-01-03', '2022-01-02', 'emprunté', 18, NULL, NULL, 9),
(38, '2022-01-03', '2022-01-04', 'emprunté', NULL, NULL, 4, 7),
(39, '2022-01-03', '2022-01-03', 'emprunté', 13, NULL, NULL, 10),
(40, '2022-01-03', '2022-01-03', 'emprunté', 18, NULL, NULL, 10),
(41, '2022-01-03', '2022-01-02', 'emprunté', 13, NULL, NULL, 10),
(44, '2022-01-03', '2022-01-01', 'emprunté', NULL, NULL, 1, 10),
(45, '2022-01-03', '2022-01-11', 'emprunté', NULL, 5, NULL, 6);

-- --------------------------------------------------------

--
-- Table structure for table `livre`
--

DROP TABLE IF EXISTS `livre`;
CREATE TABLE IF NOT EXISTS `livre` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `auteur` varchar(20) NOT NULL,
  `titre` varchar(20) NOT NULL,
  `editeur` varchar(20) NOT NULL,
  `numeroOuvrage` int(11) NOT NULL,
  `quantite` varchar(20) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=19 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `livre`
--

INSERT INTO `livre` (`id`, `auteur`, `titre`, `editeur`, `numeroOuvrage`, `quantite`) VALUES
(13, 'mohammed', 'g', 'sg', 4, '6'),
(18, 'fsgh', 'gdnh', 'hdfhw', 12, '7'),
(10, 'fsgh', 'gdnh', 'hdfhw', 12, '7'),
(11, 'sdghs', 'gf', 'fjdj', 13, '15'),
(14, 'victor', 'ghg', 'sg', 7, '4');

-- --------------------------------------------------------

--
-- Table structure for table `periodique`
--

DROP TABLE IF EXISTS `periodique`;
CREATE TABLE IF NOT EXISTS `periodique` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(20) NOT NULL,
  `numero` int(11) NOT NULL,
  `periodicite` varchar(20) NOT NULL,
  `numeroOuvrage` int(11) NOT NULL,
  `quantite` varchar(20) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `periodique`
--

INSERT INTO `periodique` (`id`, `nom`, `numero`, `periodicite`, `numeroOuvrage`, `quantite`) VALUES
(1, 'kasita', 15, '1 mois', 78, '7'),
(4, 'berchid', 78, '3 mois', 1, '25'),
(5, 'test', 78, '3 mois', 13, '3 mois');

-- --------------------------------------------------------

--
-- Table structure for table `utilisateur`
--

DROP TABLE IF EXISTS `utilisateur`;
CREATE TABLE IF NOT EXISTS `utilisateur` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(20) NOT NULL,
  `cin` varchar(20) NOT NULL,
  `password` varchar(20) NOT NULL,
  `type` varchar(20) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `utilisateur`
--

INSERT INTO `utilisateur` (`id`, `nom`, `cin`, `password`, `type`) VALUES
(7, 'badr', 'esgd565', '123456', 'simple'),
(2, 'oussamaBen', 'EA12753', '123456', 'simple'),
(3, 'houria', 'RR40197', '123456', 'simple'),
(4, 'barca', 'EERAU889', '123456', 'simple'),
(6, 'm', 'bsfg', '123', 'admin'),
(8, 'latifa', 'OUP45', '123456', 'simple'),
(9, 'mAdmin', 'ghkdjgl', '123', 'admin'),
(10, 'test', 'sgg', '123', 'simple');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
