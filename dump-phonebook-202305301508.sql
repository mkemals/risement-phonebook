--
-- PostgreSQL database dump
--

-- Dumped from database version 15.2
-- Dumped by pg_dump version 15.2

-- Started on 2023-05-30 15:08:49

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 3360 (class 1262 OID 21105)
-- Name: phonebook; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE phonebook WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'English_United States.1252';


ALTER DATABASE phonebook OWNER TO postgres;

\connect phonebook

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 4 (class 2615 OID 2200)
-- Name: public; Type: SCHEMA; Schema: -; Owner: pg_database_owner
--

CREATE SCHEMA public;


ALTER SCHEMA public OWNER TO pg_database_owner;

--
-- TOC entry 3361 (class 0 OID 0)
-- Dependencies: 4
-- Name: SCHEMA public; Type: COMMENT; Schema: -; Owner: pg_database_owner
--

COMMENT ON SCHEMA public IS 'standard public schema';


SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 215 (class 1259 OID 21255)
-- Name: contact; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.contact (
    contact_id uuid DEFAULT gen_random_uuid() NOT NULL,
    person_id uuid NOT NULL,
    contact_type_id smallint NOT NULL,
    contact_info character varying NOT NULL,
    by_default boolean DEFAULT false NOT NULL,
    deleted boolean DEFAULT false,
    created_date timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    deleted_date timestamp without time zone
);


ALTER TABLE public.contact OWNER TO postgres;

--
-- TOC entry 216 (class 1259 OID 21266)
-- Name: contact_type; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.contact_type (
    contact_type_id smallint NOT NULL,
    contact_type_name character varying NOT NULL
);


ALTER TABLE public.contact_type OWNER TO postgres;

--
-- TOC entry 214 (class 1259 OID 21245)
-- Name: person; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.person (
    person_id uuid DEFAULT gen_random_uuid() NOT NULL,
    firstname character varying,
    lastname character varying,
    firm character varying,
    deleted boolean DEFAULT false,
    created_date timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    deleted_date timestamp without time zone
);


ALTER TABLE public.person OWNER TO postgres;

--
-- TOC entry 217 (class 1259 OID 21273)
-- Name: report_gen_status; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.report_gen_status (
    report_gen_status_id smallint NOT NULL,
    report_gen_status_name character varying NOT NULL
);


ALTER TABLE public.report_gen_status OWNER TO postgres;

--
-- TOC entry 218 (class 1259 OID 21280)
-- Name: report_request; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.report_request (
    report_id uuid DEFAULT gen_random_uuid() NOT NULL,
    report_name character varying NOT NULL,
    generating_status smallint DEFAULT 1,
    request_date timestamp without time zone DEFAULT CURRENT_TIMESTAMP
);


ALTER TABLE public.report_request OWNER TO postgres;

--
-- TOC entry 3351 (class 0 OID 21255)
-- Dependencies: 215
-- Data for Name: contact; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.contact VALUES ('ff3d295b-dabd-4b49-8f5e-44efd12c7a43', '4ef5a26a-1988-4e30-aa7f-dc07ad374402', 1, '0 532 270 1010', true, false, '2023-05-29 18:07:19.50545', NULL);
INSERT INTO public.contact VALUES ('04e95ba6-5849-4659-b351-bf8cd1882b61', '4ef5a26a-1988-4e30-aa7f-dc07ad374402', 2, 'mkemals4@gmail.com', true, false, '2023-05-29 18:07:19.508017', NULL);


--
-- TOC entry 3352 (class 0 OID 21266)
-- Dependencies: 216
-- Data for Name: contact_type; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.contact_type VALUES (1, 'Telefon Numarası');
INSERT INTO public.contact_type VALUES (2, 'E-Mail');
INSERT INTO public.contact_type VALUES (3, 'Konum');


--
-- TOC entry 3350 (class 0 OID 21245)
-- Dependencies: 214
-- Data for Name: person; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.person VALUES ('4ef5a26a-1988-4e30-aa7f-dc07ad374402', 'Mustafa Kemal', 'Sürmeneli', 'İBB', false, '2023-05-29 18:06:15.054204', NULL);


--
-- TOC entry 3353 (class 0 OID 21273)
-- Dependencies: 217
-- Data for Name: report_gen_status; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.report_gen_status VALUES (1, 'Hazırlanıyor');
INSERT INTO public.report_gen_status VALUES (2, 'Tamamlandı');


--
-- TOC entry 3354 (class 0 OID 21280)
-- Dependencies: 218
-- Data for Name: report_request; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 3201 (class 2606 OID 21265)
-- Name: contact contact_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.contact
    ADD CONSTRAINT contact_pkey PRIMARY KEY (contact_id);


--
-- TOC entry 3203 (class 2606 OID 21272)
-- Name: contact_type contact_type_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.contact_type
    ADD CONSTRAINT contact_type_pkey PRIMARY KEY (contact_type_id);


--
-- TOC entry 3199 (class 2606 OID 21254)
-- Name: person person_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.person
    ADD CONSTRAINT person_pkey PRIMARY KEY (person_id);


--
-- TOC entry 3205 (class 2606 OID 21279)
-- Name: report_gen_status report_gen_status_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.report_gen_status
    ADD CONSTRAINT report_gen_status_pkey PRIMARY KEY (report_gen_status_id);


--
-- TOC entry 3207 (class 2606 OID 21289)
-- Name: report_request report_request_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.report_request
    ADD CONSTRAINT report_request_pkey PRIMARY KEY (report_id);


-- Completed on 2023-05-30 15:08:50

--
-- PostgreSQL database dump complete
--

