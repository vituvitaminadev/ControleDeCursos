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

--
-- Extraindo dados da tabela `tbl_curso`
--

INSERT INTO `tbl_curso` (`codigo`, `nomeCurso`, `conteudo`, `valorMensalidade`, `cargaHoraria`) VALUES
(3, 'eotestes', 'nao apaga pelo amor de deus', 130, 12),
(4, 'dale', 'dale', 13, 13),
(6, 'dile', 'dile', 15, 15),
(7, 'nu ta daqnaip', 'fhkldasgjfasdfsdaflasdfsdhafdjkahs', 130, 12),
(8, 'teste', 'wa', 12, 12);

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

--
-- Extraindo dados da tabela `tbl_professor`
--

INSERT INTO `tbl_professor` (`codigo`, `nome`, `valorHoraAula`, `telefone`) VALUES
(4, 'Claudin da 12 violenta', 12, '31975003346'),
(5, 'jovi', 14, '3123131231'),
(7, 'junin', 10, '83127325132'),
(8, 'wa', 12, '31232132132');

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
-- Extraindo dados da tabela `tbl_turma`
--

INSERT INTO `tbl_turma` (`codigo`, `idCurso`, `dataInicio`, `dataTermino`, `horaInicio`, `horaTermino`, `idProfessor`) VALUES
(1, 3, '2021-09-23', '2021-09-30', '13:00', '14:00', 4),
(14, 7, '2021-09-24', '2021-09-24', '13:00', '15:00', 7);

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
