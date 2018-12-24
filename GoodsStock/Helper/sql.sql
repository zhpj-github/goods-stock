CREATE TABLE `goods_type` (
  `id` INTEGER NOT NULL CONSTRAINT pk_goods_type PRIMARY KEY AUTOINCREMENT,
  `name` varchar(45) DEFAULT NULL, --COMMENT '类型名称'
  `spec` varchar(45) DEFAULT NULL, --COMMENT '规格'
  `disable` tinyint(1) DEFAULT '0'
);
CREATE TABLE `goods` (
  `id` INTEGER NOT NULL CONSTRAINT pk_goods PRIMARY KEY AUTOINCREMENT,
  `code` varchar(45) DEFAULT NULL UNIQUE,
  `name` varchar(45) NOT NULL,
  `spec_id` INTEGER NOT NULL ,-- '规格ID，即单位（箱、瓶等）'
  `unit` INTEGER DEFAULT '1' ,--COMMENT '最小单位'
  `remark` varchar(100) DEFAULT NULL,
  `disable` tinyint(1) DEFAULT '0',
  `quantity` decimal(18,3) DEFAULT '0.000',
  CONSTRAINT fk_spec_goods FOREIGN KEY (`spec_id`) REFERENCES `goods_type` (`id`)
);
CREATE TABLE `stock` (
  `id` INTEGER NOT NULL CONSTRAINT pk_stock PRIMARY KEY AUTOINCREMENT,
  `goods_id` INTEGER NOT NULL, -- '商品ID'
  `amount` decimal(18,3) DEFAULT NULL, -- '库存数量'
  CONSTRAINT fk_goods_stock FOREIGN KEY (`goods_id`) REFERENCES `goods` (`id`)
);
CREATE TABLE `check_list_bill` (
  `id` INTEGER NOT NULL CONSTRAINT pk_bill PRIMARY KEY AUTOINCREMENT,
  `check_time` datetime NOT NULL DEFAULT (datetime('now')),
  `remark` varchar(400) DEFAULT NULL
);
CREATE TABLE `check_list_detail` (
  `id` INTEGER NOT NULL CONSTRAINT pk_detail PRIMARY KEY AUTOINCREMENT,
  `bill_id` INTEGER NOT NULL,
  `goods_id` INTEGER NOT NULL,
  `quantity` decimal(18,3) DEFAULT NULL ,
  `raw_quantity` decimal(18,3) DEFAULT NULL,
  CONSTRAINT fk_bill_detail FOREIGN KEY (`bill_id`) REFERENCES `check_list_bill` (`id`),
  CONSTRAINT fk_goods_detail FOREIGN KEY (`goods_id`) REFERENCES `goods` (`id`)
);
