CREATE TABLE IF NOT EXISTS public.users
(
    user_id uuid NOT NULL,
    user_name text COLLATE pg_catalog."default" NOT NULL,
    email text COLLATE pg_catalog."default" NOT NULL,
    registration_date timestamp without time zone NOT NULL,
    CONSTRAINT users_pkey PRIMARY KEY (user_id)
)

CREATE TABLE IF NOT EXISTS public.products
(
    product_id uuid NOT NULL,
    product_name text COLLATE pg_catalog."default" NOT NULL,
    description text COLLATE pg_catalog."default" NOT NULL,
    price numeric NOT NULL,
    quantity_in_stock integer NOT NULL,
    CONSTRAINT products_pkey PRIMARY KEY (product_id)
)

CREATE TABLE IF NOT EXISTS public.orders
(
    order_id uuid NOT NULL,
    user_id uuid NOT NULL,
    order_date timestamp without time zone NOT NULL,
    status smallint NOT NULL,
    CONSTRAINT orders_pkey PRIMARY KEY (order_id),
    CONSTRAINT fk_orders_user_id FOREIGN KEY (user_id)
        REFERENCES public.users (user_id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

CREATE TABLE IF NOT EXISTS public.order_details
(
    order_detail_id uuid NOT NULL,
    order_id uuid NOT NULL,
    product_id uuid NOT NULL,
    quantity integer NOT NULL,
    total_cost numeric NOT NULL,
    CONSTRAINT order_details_pkey PRIMARY KEY (order_detail_id),
    CONSTRAINT fk_order_details_order_id FOREIGN KEY (order_id)
        REFERENCES public.orders (order_id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT fk_order_details_product_id FOREIGN KEY (product_id)
        REFERENCES public.products (product_id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)