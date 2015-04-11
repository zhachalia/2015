/*
Navicat MySQL Data Transfer

Source Server         : local
Source Server Version : 50621
Source Host           : localhost:3306
Source Database       : activeserver

Target Server Type    : MYSQL
Target Server Version : 50621
File Encoding         : 65001

Date: 2015-03-27 23:46:54
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for t_code
-- ----------------------------
DROP TABLE IF EXISTS `t_code`;
CREATE TABLE `t_code` (
  `code_str` varchar(50) NOT NULL,
  `code_type` tinyint(2) NOT NULL,
  `code_valid` int(1) DEFAULT NULL,
  `code_date_len` int(11) DEFAULT NULL,
  `code_date_start` date DEFAULT NULL,
  `code_date_end` date DEFAULT NULL,
  `code_desc` varchar(50) DEFAULT NULL,
  `code_enable_computers` int(3) unsigned zerofill DEFAULT '000',
  `code_used_computers` int(3) unsigned zerofill DEFAULT '000',
  PRIMARY KEY (`code_str`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_code
-- ----------------------------
INSERT INTO `t_code` VALUES ('AS23G-7AXCM-J343M-TZ32B-JGM26', '1', '1', null, '2015-03-26', '2050-12-31', null, '001', '000');
INSERT INTO `t_code` VALUES ('CJUSK-GDYMM-TTCS3-VFRVX-TVHNJ', '1', '1', null, '2015-03-26', '2050-12-31', null, '001', '000');
INSERT INTO `t_code` VALUES ('VYEEX-SBGHK-YM7DK-S6AFT-3MYHE', '2', '1', null, '2015-03-26', '2015-03-26', null, '002', '000');

-- ----------------------------
-- Table structure for t_userinfo
-- ----------------------------
DROP TABLE IF EXISTS `t_userinfo`;
CREATE TABLE `t_userinfo` (
  `user_id` int(11) NOT NULL AUTO_INCREMENT,
  `code_str` varchar(50) DEFAULT NULL,
  `user_computer` varchar(200) DEFAULT NULL,
  `user_name` varchar(100) DEFAULT NULL,
  `user_org` varchar(100) DEFAULT NULL,
  `reg_time` datetime DEFAULT NULL,
  `reg_computer_ip` varchar(100) DEFAULT NULL,
  `reg_computer_name` varchar(100) DEFAULT NULL,
  `reg_state` int(1) NOT NULL,
  `reg_desc` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_userinfo
-- ----------------------------
