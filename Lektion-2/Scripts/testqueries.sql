SELECT 
*
FROM customers INNER JOIN salesorders
    ON customers.id = salesorders.customer_id;

    DELETE FROM salesorders WHERE id = 1;
    DELETE FROM customers WHERE id = 1;

    SELECT * FROM salesorders;

    SELECT * FROM customers;

    SELECT * From products;
    SELECT * FROM suppliers;
    SELECT * FROM orderitems;

    SELECT
        ordernumber,
        orderdate,
        -- firstname || ' ' || lastname,
        firstname,
        lastname,
        customers.email,
        productname,
        suppliername,
        quantity,
        orderitems.price,
        discount,
        quantity * orderitems.price AS linesum
    FROM salesorders INNER JOIN orderitems
        On salesorders.id = orderitems.order_id INNER JOIN products
        ON orderitems.product_id = products.id INNER JOIN suppliers
        On products.supplier_id = suppliers.id INNER JOIN customers
        ON salesorders.customer_id = customers.id;
--Detta är ett annat sätt att hantera vilka columner som ska användas i kopplingar respektive columner
      --^^ med massa AS och förkortningar av namn

-- ALTER SEQUENCE customers_id_seq RESTART WITH 1;


SELECT
    firstname,
    lastname,
    addressline,
    postalcode,
    city,
    addresstype
FROM customers INNER JOIN customeraddresses
    ON customers.id = customeraddresses.customer_id INNER JOIN addresses
    ON customeraddresses.address_id = addresses.id INNER JOIN addresstypes
    ON customeraddresses.addresstype_id = addresstypes.id;
