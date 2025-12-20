--Добавление нового продукта
INSERT INTO public.products(
	product_id, product_name, description, price, quantity_in_stock)
	VALUES (gen_random_uuid(), 'Ноутбук Acer Aspire', '17 дюймовый ноутбук с подсветкой', 65000, 10);

--Обновление цены продукта
UPDATE public.products
	SET price=70000
	WHERE product_id = '31725f43-0fa4-4ee2-9f35-f785388e61ea';

--Выбор всех заказов определенного пользователя
SELECT *
	FROM public.orders
	WHERE user_id = 'df93f8de-b8fb-4987-ae4b-42d14175a1fa'  

--Расчет общей стоимости заказа
SELECT SUM(total_cost)
	FROM public.order_details
	WHERE order_id = '4126be0c-861f-4586-a9fe-2ce84a3dd5ac'          

--Подсчет количества товаров на складе
SELECT SUM(quantity_in_stock)
	FROM public.products;

--Получение 5 самых дорогих товаров
SELECT *
	FROM public.products
	ORDER BY price DESC
	LIMIT 5

--Список товаров с низким запасом (менее 5 штук)    
SELECT *
	FROM public.products
	WHERE quantity_in_stock < 5