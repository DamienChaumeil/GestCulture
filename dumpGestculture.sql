-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: May 20, 2023 at 03:55 PM
-- Server version: 8.0.30
-- PHP Version: 8.1.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `gestculture`
--

-- --------------------------------------------------------

--
-- Table structure for table `exploitation`
--

CREATE TABLE `exploitation` (
  `Id_exploi` int NOT NULL,
  `Code_exploi` text NOT NULL,
  `Nom` text NOT NULL,
  `Prenom` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `exploitation`
--

INSERT INTO `exploitation` (`Id_exploi`, `Code_exploi`, `Nom`, `Prenom`) VALUES
(1, 'Test', 'Test', 'Test'),
(2, 'Miroslav', 'penkov', 'Miroslav');

-- --------------------------------------------------------

--
-- Table structure for table `parcelle`
--

CREATE TABLE `parcelle` (
  `Id_parc` int NOT NULL,
  `Id_exploi` int NOT NULL,
  `Code_parc` text NOT NULL,
  `Espece` text NOT NULL,
  `Surface` text NOT NULL,
  `Rendement_prev` text NOT NULL,
  `Rendement_reel` text NOT NULL,
  `Annee` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `parcelle`
--

INSERT INTO `parcelle` (`Id_parc`, `Id_exploi`, `Code_parc`, `Espece`, `Surface`, `Rendement_prev`, `Rendement_reel`, `Annee`) VALUES
(1, 1, 'P1', 'Orge', '25', '0.8', '0.6', '2023'),
(2, 2, 'P1', 'Blé', '25', '0.9', '0.2', '2023'),
(3, 2, 'P2', 'Betteraves', '13', '0.8', '0.4', '2023');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `exploitation`
--
ALTER TABLE `exploitation`
  ADD PRIMARY KEY (`Id_exploi`);

--
-- Indexes for table `parcelle`
--
ALTER TABLE `parcelle`
  ADD PRIMARY KEY (`Id_parc`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `exploitation`
--
ALTER TABLE `exploitation`
  MODIFY `Id_exploi` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `parcelle`
--
ALTER TABLE `parcelle`
  MODIFY `Id_parc` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
