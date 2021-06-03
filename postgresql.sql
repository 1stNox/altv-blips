CREATE TABLE YOURDATABASE.blips
(
    id integer NOT NULL DEFAULT nextval('gta.blips_id_seq'::regclass),
    name character varying COLLATE pg_catalog."default" NOT NULL,
    type integer NOT NULL,
    color integer NOT NULL,
    scale numeric NOT NULL,
    short_range boolean NOT NULL,
    pos_x numeric NOT NULL,
    pos_y numeric NOT NULL,
    pos_z numeric NOT NULL,
    CONSTRAINT blips_pkey PRIMARY KEY (id)
)

TABLESPACE pg_default;

ALTER TABLE YOURDATABASE.blips
    OWNER to postgres;

GRANT ALL ON TABLE YOURDATABASE.blips TO YOURUSER;

GRANT ALL ON TABLE YOURDATABASE.blips TO postgres;