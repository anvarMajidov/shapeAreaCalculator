-- этот query используется для получения всех продуктов с соответсвущими ему категориями
/* так как продукт имеет несколько категорий, а категория ссылается на несколько продуктов, то в базе данных должна
   присутствовать дополнительная таблица которую я назвал product_category.
   Эта таблица содержит в себе product_id и category_id(ниже я прикрепил query для этой таблицы)
 */

select p.product_id, p.product_name, c.category_id, c.category_name
from product as p
    left join product_category as pc on p.product_id = pc.product_id
    left join category as c on c.category_id = pc.category_id;

-- query для таблицы product_category
CREATE TABLE Product_Category (
    product_id int NOT NULL,
    category_id int NOT NULL,
    CONSTRAINT product_cat_pk PRIMARY KEY (product_id,category_id),
    CONSTRAINT FK_category FOREIGN KEY (category_id) REFERENCES Category(category_id),
    CONSTRAINT FK_product FOREIGN KEY (product_id) REFERENCES Product(product_id)
);