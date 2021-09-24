-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Tempo de geração: 24-Set-2021 às 21:02
-- Versão do servidor: 5.7.31
-- versão do PHP: 7.3.21

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `cursos_bd`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `tbl_curso`
--

DROP TABLE IF EXISTS `tbl_curso`;
CREATE TABLE IF NOT EXISTS `tbl_curso` (
  `codigo` int(11) NOT NULL AUTO_INCREMENT,
  `nomeCurso` varchar(40) NOT NULL,
  `conteudo` varchar(200) NOT NULL,
  `valorMensalidade` double NOT NULL,
  `cargaHoraria` int(11) NOT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tbl_professor`
--

DROP TABLE IF EXISTS `tbl_professor`;
CREATE TABLE IF NOT EXISTS `tbl_professor` (
  `codigo` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(40) NOT NULL,
  `valorHoraAula` double NOT NULL,
  `telefone` varchar(20) NOT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tbl_turma`
--

DROP TABLE IF EXISTS `tbl_turma`;
CREATE TABLE IF NOT EXISTS `tbl_turma` (
  `codigo` int(11) NOT NULL AUTO_INCREMENT,
  `idCurso` int(11) NOT NULL,
  `dataInicio` date NOT NULL,
  `dataTermino` date NOT NULL,
  `horaInicio` varchar(5) NOT NULL,
  `horaTermino` varchar(5) NOT NULL,
  `idProfessor` int(11) NOT NULL,
  PRIMARY KEY (`codigo`),
  KEY `idProfessor` (`idProfessor`),
  KEY `idCurso` (`idCurso`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8;

--
-- Restrições para despejos de tabelas
--

--
-- Limitadores para a tabela `tbl_turma`
--
ALTER TABLE `tbl_turma`
  ADD CONSTRAINT `tbl_turma_ibfk_1` FOREIGN KEY (`idProfessor`) REFERENCES `tbl_professor` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `tbl_turma_ibfk_2` FOREIGN KEY (`idCurso`) REFERENCES `tbl_curso` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
