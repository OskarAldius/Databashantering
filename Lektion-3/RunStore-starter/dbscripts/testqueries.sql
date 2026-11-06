SELECT 
    products.id,
    itemnumber,
    productname,
    price,
    suppliername
FROM products INNER JOIN suppliers
    ON products.supplier_id = suppliers.id;

SELECT
*
FROM customers;

SELECT
salesorders.id,
orderdate,
firstname,
lastname,
email,
quantity *  orderitems.price AS OrderSum


FROM salesorders INNER JOIN orderitems
    ON salesorders.id = orderitems.order_id INNER JOIN customers
    ON salesorders.id = customers.id;
