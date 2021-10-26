create database if not exists Sales;
use Sales;

create table if not exists Sales(
id int auto_increment,
product_name varchar(64),
sale_quantity int NOT NULL,
item_price double NOT NULL,
sale_date datetime NOT NULL DEFAULT(current_date()),
primary key(id)
);

select * from Sales;
