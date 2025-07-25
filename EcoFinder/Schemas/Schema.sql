drop database ECOFINDER;


create database ECOFINDER;
use ECOFINDER;
SET GLOBAL event_scheduler = ON;
set SQL_SAFE_UPDATES = 0;
SET @@autocommit = OFF;
create table tb_pessoa
(
    id_pessoa      int auto_increment primary key not null,
    nome           varchar(250)                   not null,
    email          varchar(250) unique            not null,
    senha          varchar(250)                   not null,
    genero         varchar(20)                    not null,
    situacao_conta enum ('ATIVA','INATIVA') default 'ATIVA'
);

create table tb_endereco
(
    id_endereco        int auto_increment primary key not null,
    id_pessoa_endereco int unique                     not null,
    cep                varchar(10)                    not null,
    estado             varchar(20)                    not null,
    cidade             varchar(50)                    not null,
    bairro             varchar(150)                   not null,
    rua                varchar(250)                   not null,
    numerocasa         varchar(10)                    not null,
    latitude           decimal(9, 6),
    longitude          decimal(9, 6),
    foreign key (id_pessoa_endereco) references tb_pessoa (id_pessoa)
);
create index indx_cep on tb_endereco (cep);
create index indx_pessoa_endereco on tb_endereco (id_pessoa_endereco);

create table tb_log_edit_user_end
(
    id_log_edit_end    int auto_increment primary key,
    id_endereco        int                                not null,
    id_pessoa_endereco int                                not null,
    old_cep            varchar(10)                        not null,
    new_cep            varchar(10)                        not null,
    old_estado         varchar(20)                        not null,
    new_estado         varchar(20)                        not null,
    old_cidade         varchar(50)                        not null,
    new_cidade         varchar(50)                        not null,
    old_bairro         varchar(150)                       not null,
    new_bairro         varchar(150)                       not null,
    old_rua            varchar(250)                       not null,
    new_rua            varchar(250)                       not null,
    old_numerocasa     varchar(10)                        not null,
    new_numerocasa     varchar(10)                        not null,
    old_latitude       decimal(9, 6),
    new_latitude       decimal(9, 6),
    old_longitude      decimal(9, 6),
    new_longitude      decimal(9, 6),
    data_alteracao     datetime default current_timestamp not null,
    foreign key (id_pessoa_endereco) references tb_pessoa (id_pessoa),
    foreign key (id_endereco) references tb_endereco (id_endereco)
);

create table tb_log_edit_perfil
(
    id_log_edit_perfil int auto_increment primary key,
    id_pessoa          int                                not null,
    old_nome           varchar(50)                        not null,
    new_nome           varchar(50)                        not null,
    old_email          varchar(250)                       not null,
    new_email          varchar(250)                       not null,
    old_senha          varchar(250)                       not null,
    new_senha          varchar(250)                       not null,
    old_genero         varchar(20)                        not null,
    new_genero         varchar(20)                        not null,
    data_alteracao     datetime default current_timestamp not null,
    foreign key (id_pessoa) references tb_pessoa (id_pessoa)
);

create table tb_material
(
    id_material int auto_increment primary key not null,
    tipo        varchar(20)                    not null
);

create index inx_material_tipo on tb_material (tipo);

create table tb_coletor
(
    id_coletor         int primary key,
    quantidade_coletas int default 0 not null,
    coletor_strikes    int default 0,
    nivel int default 0,
    foreign key (id_coletor) references tb_pessoa (id_pessoa) on delete cascade on update restrict
);

create table tb_usuariocomum
(
    id_usuarioComum      int primary key,
    usuariocomum_strikes int default 0,
    foreign key (id_usuarioComum) references tb_pessoa (id_pessoa) on delete cascade on update restrict
);

create table tb_chamado
(
    id_chamado      int auto_increment primary key,
    id_usuarioComum int not null,
    data_chamado    datetime default current_timestamp,
    data_expiracao  DATETIME,
    foreign key (id_usuarioComum) references tb_usuariocomum (id_usuarioComum)
);


-- tabela resultado do relacionamento N:N entre tb_chamado e tb_material
-- tabela segue a regra de que um chamado nao pode possuir o mesmo tipo de material 2 vezes, tal restricao é garantida pelas PKs compostas
create table tb_chamado_material
(
    id_chamado_material int auto_increment primary key       not null,
    id_chamado          int                                  not null,
    id_material         int                                  not null,
    qtde_unitaria       int                                  not null,
    kilograma           decimal(10, 2) default 0.00          not null,
    tamanho_material    enum ('Grande', 'Médio' , 'Pequeno') not null,
    foreign key (id_chamado) references tb_chamado (id_chamado),
    foreign key (id_material) references tb_material (id_material)
);
create unique index indx_chamado_meterial on tb_chamado_material (id_chamado, id_material);


create table tb_disponibilidade
(
    id_dispo   int auto_increment primary key                                        not null,
    id_chamado int                                                                   not null,
    status     enum ('Disponivel','Reservado', 'Expirado' , 'Concluido','Cancelado') not null,
    foreign key (id_chamado) references tb_chamado (id_chamado)
);

create table tb_chamados_reservados
(
    id_chamado_reservado    int auto_increment primary key                                            not null,
    id_chamado              int unique                                                                not null,
    id_coletor              int unique                                                                not null,
    data_reserva            datetime default current_timestamp,
    data_expiracao_reserva  datetime,
    previsao_coleta         enum ('Manhã', 'Tarde' , 'Noite')                                         not null,
    status_reserva          enum ('Em andamento', 'Expirada' , 'Concluida','Cancelada','Desistencia') not null, -- o status indisponivel indentifica o chamado q foi ou cancelado, ou deletado pelo solicitante
    confirmacao_coletor     BOOLEAN  DEFAULT FALSE,
    confirmacao_solicitante BOOLEAN  DEFAULT FALSE,
    foreign key (id_chamado) references tb_chamado (id_chamado),
    foreign key (id_coletor) references tb_coletor (id_coletor)
);
create unique index indx_chamado_reservado on tb_chamados_reservados (id_chamado, id_coletor);

create table tb_hist_chamados_reservados
(
    id_hist_c_r          int auto_increment primary key                                            not null,
    id_chamado_reservado int                                                                       not null,
    id_chamado           int                                                                       not null,
    id_coletor           int                                                                       not null,
    data_hora_reserva    datetime                                                                  not null,
    previsao_coleta      enum ('Manhã', 'Tarde' , 'Noite')                                         not null,
    status_reserva       enum ('Em andamento', 'Expirada' , 'Concluida','Desistencia','Cancelada') not null, -- o status indisponivel indentifica o chamado q foi ou cancelado, ou deletado pelo solicitante
    data_modificacao     DATETIME DEFAULT CURRENT_TIMESTAMP,
    Foreign key (id_chamado_reservado) references tb_chamados_reservados (id_chamado_reservado)

);

create table tb_log_alt_chamado
(
    id_log_alt_chamado   int auto_increment primary key           not null,
    id_chamado_material  int                                      null,
    id_chamado           int                                      not null,
    old_id_material      int                                      not null,
    new_id_material      int                                      not null,
    old_qtde_unitaria    int                                      not null,
    new_qtde_unitaria    int                                      not null,
    old_kilograma        decimal(10, 2) default 0.00              not null,
    new_kilograma        decimal(10, 2) default 0.00              not null,
    old_tamanho_material enum ('Grande', 'Médio' , 'Pequeno')     not null,
    new_tamanho_material enum ('Grande', 'Médio' , 'Pequeno')     not null,
    data_alter           datetime       default current_timestamp not null,
    foreign key (id_chamado_material) references tb_chamado_material (id_chamado_material),
    foreign key (id_chamado) references tb_chamado (id_chamado),
    foreign key (old_id_material) references tb_material (id_material),
    foreign key (new_id_material) references tb_material (id_material)

);

create table tb_notifica_coletor
(

    id_mensagem          int auto_increment primary key not null,
    id_coletor           int                            not null,
    id_chamado_reservado int                            not null,
    mensagem             varchar(10000)                 not null,
    data_envio           datetime default current_timestamp,
    foreign key (id_chamado_reservado) references tb_chamados_reservados (id_chamado_reservado),
    foreign key (id_coletor) references tb_coletor (id_coletor)
);

create table tb_notifica_solicitante
(
    id_mensagem     int auto_increment primary key not null,
    id_usuariocomum int                            not null,
    id_chamado      int                            not null,
    mensagem        varchar(10000)                 not null,
    data_envio      datetime default current_timestamp,
    foreign key (id_chamado) references tb_chamado (id_chamado),
    foreign key (id_usuariocomum) references tb_usuariocomum (id_usuarioComum)
);


CREATE TABLE tb_impacto_ambiental (
    id_material INT PRIMARY KEY,
    litros_petroleo_por_kg DECIMAL(10, 2) DEFAULT 0.00,
    kw_economia_energia DECIMAL(10, 2) DEFAULT 0.00,
    co2_kg_evitar DECIMAL(10, 2) DEFAULT 0.00,
    FOREIGN KEY (id_material) REFERENCES tb_material(id_material)
);


INSERT INTO tb_material (tipo)
VALUES ('Plástico');
INSERT INTO tb_material (tipo)
VALUES ('Papel');
INSERT INTO tb_material (tipo)
VALUES ('Metal');
INSERT INTO tb_material (tipo)
VALUES ('Vidro');
INSERT INTO tb_material (tipo)
VALUES ('Eletrônico');

INSERT INTO tb_impacto_ambiental (id_material, litros_petroleo_por_kg, kw_economia_energia, co2_kg_evitar)
VALUES
(1, 0.38, 5.4, 1.8),  -- Plástico
(2, 0.00, 2.3, 0.9),  -- Papel
(3, 0.00, 4.0, 2.5),  -- Metal
(4, 0.00, 3.2, 1.0);  -- Vidro (exemplo extra)

 use ecofinder;
DELIMITER //
CREATE TRIGGER TG_UP_STATUS_CHAMDO_AFTER_RESERV_EXPIRACAO
    AFTER UPDATE
    ON tb_chamados_reservados
    FOR EACH ROW
BEGIN
    DECLARE v_id_usuariocomum INT;
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET v_id_usuariocomum = NULL;


    IF OLD.status_reserva = 'Em andamento' AND NEW.status_reserva = 'Expirada' THEN

        UPDATE tb_disponibilidade
        SET status = 'Disponivel'
        WHERE id_chamado = OLD.id_chamado;

        UPDATE tb_chamado
        SET data_expiracao = NOW() + INTERVAL 1 DAY
        WHERE id_chamado = OLD.id_chamado;

        SELECT id_usuariocomum
        INTO v_id_usuariocomum
        FROM tb_chamado
        WHERE id_chamado = OLD.id_chamado;
        IF v_id_usuariocomum IS NOT NULL THEN
            INSERT INTO tb_notifica_solicitante (id_usuariocomum,
                                                 id_chamado,
                                                 mensagem)
            VALUES (v_id_usuariocomum,
                    OLD.id_chamado,
                    CONCAT(
                            'ATENÇÃO! O coletor(a) que havia reservado seu chamado número ',
                            OLD.id_chamado,
                            ' teve a reserva expirada. Seu chamado foi reativado e está disponível novamente com nova data de expiração.'
                    ));
        END IF;
    END IF;
END //
DELIMITER ;


-- trigger para notificar ao solicitante que a previção da coleta de um chamado foi alterada
DELIMITER //
CREATE TRIGGER tg_alter_previsao__coleta
    AFTER UPDATE
    ON tb_chamados_reservados
    FOR EACH ROW
BEGIN

    declare v_nome_coletor varchar(250) default '';
    declare v_id_usuariocomum int default 0;

    IF new.previsao_coleta <> old.previsao_coleta then
        select nome
        into v_nome_coletor
        from tb_pessoa
        where id_pessoa = NEW.id_coletor
        limit 1;

        -- pegando o id do usuario dono do chamado
        select tb_chamado.id_usuariocomum
        into v_id_usuariocomum
        from tb_usuariocomum
                 inner join tb_chamado on tb_chamado.id_usuarioComum = tb_usuariocomum.id_usuarioComum
                 inner join tb_chamados_reservados on tb_chamados_reservados.id_chamado = tb_chamado.id_chamado
        where tb_chamado.id_chamado = OLD.id_chamado
        limit 1;

        INSERT INTO tb_notifica_solicitante(id_chamado,
                                            id_usuariocomum,
                                            mensagem)
        values (old.id_chamado,
                v_id_usuariocomum,
                CONCAT(
                        'ATENÇÃO: o(a) coletor(a) ', v_nome_coletor,
                        ', que reservou o chamado de número ', old.id_chamado,
                        ', alterou o período de coleta para ', new.previsao_coleta,
                        ', substituindo o período anteriormente informado: ', old.previsao_coleta
                ));

    END IF;
END //
DELIMITER ;

-- trigger para soma de reservas acumuladoas ao longo do tempo pelo coletor
DELIMITER &&
CREATE TRIGGER tg_quantidade_coleta
AFTER UPDATE ON tb_chamados_reservados
FOR EACH ROW
BEGIN
     IF NEW.confirmacao_coletor = TRUE AND NEW.confirmacao_solicitante = TRUE AND
       (OLD.confirmacao_coletor <> TRUE OR OLD.confirmacao_solicitante <> TRUE) THEN

        UPDATE tb_coletor
        SET quantidade_coletas = quantidade_coletas + 1
        WHERE id_coletor = NEW.id_coletor;

    END IF;
END &&
DELIMITER ;


-- trigger paar atualizacao de status de chamado para reservado na tb_disponibilidade, ao ser reservado por um coletor na tb_chamdos_reservados
delimiter //
create trigger tg_Up_status_Insert_notifica_solicitante
    after insert
    on tb_chamados_reservados
    for each row
begin
    declare v_nome_coletor varchar(250) default '';
    declare v_id_usuariocomum int default 0;

    update tb_disponibilidade
    set status = 'Reservado'
    where id_chamado = new.id_chamado;

    -- inserindo na tb_notifica_solicitante ----------------------------------------------------------
    select nome
    into v_nome_coletor
    from tb_pessoa
    where id_pessoa = NEW.id_coletor
    limit 1;

    select id_usuarioComum
    into v_id_usuariocomum
    from tb_chamado
    where id_chamado = NEW.id_chamado
    limit 1;

    INSERT INTO tb_notifica_solicitante(id_chamado,
                                        id_usuariocomum,
                                        mensagem)
    values (new.id_chamado,
            v_id_usuariocomum,
            CONCAT('ATENÇÃO seu chamado de número ', new.id_chamado, ' foi reservado pelo(a) COLETOR(A): ',
                   v_nome_coletor, ', com previsão de coleta: ', new.previsao_coleta));

end //
delimiter ;
-- trigger para fazer registro de alteraçõe sd eendereços, e caspo esse endereço que foi alterado esta ligado a um chamado, o coletor é avisado sobre-----------------------
DELIMITER //
CREATE TRIGGER TG_ALTER_ENDERECO
AFTER UPDATE ON tb_endereco
FOR EACH ROW
BEGIN
    DECLARE v_id_coletor INT DEFAULT NULL;
    DECLARE v_id_chamado INT DEFAULT NULL;
    DECLARE v_id_chamado_reservado INT DEFAULT NULL;
    DECLARE v_is_usuario_comum BOOLEAN DEFAULT FALSE;
    DECLARE v_nome_solicitante VARCHAR(250) DEFAULT '';

    -- Verifica se houve mudança real no endereço
    IF (OLD.cep <> NEW.cep OR
        OLD.estado <> NEW.estado OR
        OLD.cidade <> NEW.cidade OR
        OLD.bairro <> NEW.bairro OR
        OLD.rua <> NEW.rua OR
        OLD.numerocasa <> NEW.numerocasa OR
        OLD.latitude <> NEW.latitude OR
        OLD.longitude <> NEW.longitude) THEN

        -- Registra no log de alterações (sempre que houver mudança)
        INSERT INTO tb_log_edit_user_end(
            id_endereco, id_pessoa_endereco,
            old_cep, new_cep,
            old_estado, new_estado,
            old_cidade, new_cidade,
            old_bairro, new_bairro,
            old_rua, new_rua,
            old_numerocasa, new_numerocasa,
            old_latitude, new_latitude,
            old_longitude, new_longitude
        ) VALUES (
            OLD.id_endereco, OLD.id_pessoa_endereco,
            OLD.cep, NEW.cep,
            OLD.estado, NEW.estado,
            OLD.cidade, NEW.cidade,
            OLD.bairro, NEW.bairro,
            OLD.rua, NEW.rua,
            OLD.numerocasa, NEW.numerocasa,
            OLD.latitude, NEW.latitude,
            OLD.longitude, NEW.longitude
        );

        -- Verifica se o endereço pertence a um usuário comum (que pode ter chamados)
        SELECT COUNT(*) > 0 INTO v_is_usuario_comum
        FROM tb_usuariocomum
        WHERE id_usuarioComum = OLD.id_pessoa_endereco;

        -- Se for usuário comum, verifica se tem chamados reservados ATIVOS
        IF v_is_usuario_comum THEN
            -- Pega informações do chamado reservado em andamento
            SELECT
                cr.id_coletor,
                c.id_chamado,
                cr.id_chamado_reservado,
                p.nome
            INTO
                v_id_coletor,
                v_id_chamado,
                v_id_chamado_reservado,
                v_nome_solicitante
            FROM tb_chamado c
            JOIN tb_chamados_reservados cr ON cr.id_chamado = c.id_chamado
            JOIN tb_pessoa p ON p.id_pessoa = c.id_usuarioComum
            WHERE c.id_usuarioComum = OLD.id_pessoa_endereco
            AND cr.status_reserva = 'Em andamento'
            LIMIT 1;

            -- Se encontrou um chamado reservado ativo, cria notificação
            IF v_id_coletor IS NOT NULL AND v_id_chamado_reservado IS NOT NULL THEN
                INSERT INTO tb_notifica_coletor(
                    id_chamado_reservado,
                    id_coletor,
                    mensagem
                ) VALUES (
                    v_id_chamado_reservado,
                    v_id_coletor,
                    CONCAT('ATENÇÃO COLETOR! O endereço do chamado #', v_id_chamado,
                           ' (solicitante: ', v_nome_solicitante,
                           ') foi alterado. Verifique os novos detalhes:',
                           '\n- Endereço atualizado: ', NEW.rua, ', ', NEW.numerocasa,
                           ', ', NEW.bairro, ', ', NEW.cidade, '-', NEW.estado,
                           '\n- CEP: ', NEW.cep)
                );
            END IF;
        END IF;
    END IF;
END//
DELIMITER ;

-- trigger para log de alterações em chamados, e caso esse chamdo que esta sendo alterado esteja reservado, o coletor é notificado---
DELIMITER //
CREATE TRIGGER tr_alter_chamado_infos
    AFTER UPDATE
    ON tb_chamado_material
    FOR EACH ROW
BEGIN
    declare v_id_coletor int default 0;
    declare v_id_chamado_reservado int default 0;


    INSERT INTO tb_log_alt_chamado
    (id_chamado_material,
     id_chamado,
     old_id_material,
     new_id_material,
     old_qtde_unitaria,
     new_qtde_unitaria,
     old_kilograma,
     new_kilograma,
     old_tamanho_material,
     new_tamanho_material)
    VALUES (OLD.id_chamado_material,
            OLD.id_chamado,
            OLD.id_material,
            NEW.id_material,
            OLD.qtde_unitaria,
            NEW.qtde_unitaria,
            OLD.kilograma,
            NEW.kilograma,
            OLD.tamanho_material,
            NEW.tamanho_material);

    IF EXISTS (SELECT id_chamado
               FROM tb_chamados_reservados
               where tb_chamados_reservados.id_chamado = old.id_chamado
               limit 1)
    THEN

        SELECT tb_chamados_reservados.id_coletor, tb_chamados_reservados.id_chamado_reservado
        INTO v_id_coletor, v_id_chamado_reservado
        FROM tb_chamados_reservados
        WHERE tb_chamados_reservados.id_chamado = OLD.id_chamado
        LIMIT 1;

        INSERT INTO tb_notifica_coletor(id_chamado_reservado,
                                        id_coletor,
                                        mensagem)
        VALUES (v_id_chamado_reservado,
                v_id_coletor,
                CONCAT('ATENÇÃO COLETOR(A)! o chamado número ', old.id_chamado,
                       ' foi atualizado!. Por favor, verifique se ele ainda atende às suas necessidades!'));
    END IF;
END;
//
DELIMITER ;

-- trigger para fazer log de alteraçõe nas informacoes pessoas dos usuarios
DELIMITER //
CREATE TRIGGER TB_ALTER_USER_INFOS
    AFTER UPDATE
    ON tb_pessoa
    FOR EACH ROW
BEGIN
    INSERT INTO tb_log_edit_perfil(id_pessoa,
                                   old_nome,
                                   new_nome,
                                   old_email,
                                   new_email,
                                   old_senha,
                                   new_senha,
                                   old_genero,
                                   new_genero)
    VALUES (OLD.id_pessoa,
            OLD.nome,
            NEW.nome,
            OLD.email,
            NEW.email,
            OLD.senha,
            NEW.senha,
            OLD.genero,
            NEW.genero);
END //
DELIMITER ;


-- Trigger para definir data_expiracao automaticamente
DELIMITER //
CREATE TRIGGER tg_set_dt_expiracao_chamado
    BEFORE INSERT
    ON tb_chamado
    FOR EACH ROW
BEGIN
    IF NEW.data_expiracao IS NULL THEN
        SET NEW.data_expiracao = NOW() + INTERVAL 1 DAY;
    END IF;
END;
//
DELIMITER ;


-- Trigger para definir data_expiracao da reserva automaticamente
DELIMITER //
CREATE TRIGGER tg_set_dt_expiracao_reserva
    BEFORE INSERT
    ON tb_chamados_reservados
    FOR EACH ROW
BEGIN
    IF NEW.data_expiracao_reserva IS NULL THEN
        SET NEW.data_expiracao_reserva = NOW() + INTERVAL 1 DAY;
    END IF;
END;
//
DELIMITER ;


DELIMITER //
CREATE TRIGGER tg_cont_strikes
    AFTER UPDATE
    ON tb_chamados_reservados
    FOR EACH ROW
BEGIN
    DECLARE v_nome_coletor VARCHAR(250) DEFAULT '';
    DECLARE v_id_coletor INT DEFAULT 0;
    DECLARE v_id_usuariocomum INT DEFAULT 0;

    IF EXISTS (SELECT 1 FROM tb_coletor WHERE id_coletor = new.id_coletor) THEN
        SELECT id_coletor, nome
        INTO v_id_coletor, v_nome_coletor
        FROM tb_coletor
                 INNER JOIN tb_pessoa ON tb_coletor.id_coletor = tb_pessoa.id_pessoa
        WHERE id_coletor = new.id_coletor
        LIMIT 1;
    END IF;

    -- pegando o id do solicitane para avisa-lo que a reserva expirou e seu chamdo esta disponivel novamente
    SELECT tb_usuariocomum.id_usuarioComum
    INTO v_id_usuariocomum
    FROM tb_usuariocomum
             INNER JOIN tb_pessoa ON tb_usuariocomum.id_usuarioComum = tb_pessoa.id_pessoa
             INNER JOIN tb_chamado ON tb_chamado.id_usuarioComum = tb_usuariocomum.id_usuarioComum
    WHERE tb_chamado.id_chamado = old.id_chamado
    LIMIT 1;


    IF old.status_reserva = 'Em andamento' AND NEW.status_reserva = 'Expirada' THEN
        UPDATE tb_coletor
        SET coletor_strikes = coletor_strikes + 1
        WHERE id_coletor = new.id_coletor;

        INSERT INTO tb_notifica_coletor(id_coletor,
                                        id_chamado_reservado,
                                        mensagem)
        VALUES (new.id_coletor,
                new.id_chamado_reservado,
                CONCAT(
                        'ATENCAO COLETOR(A) ', v_nome_coletor, ' sua reserva do chamado de número ',
                        new.id_chamado,
                        ' expirou!, será contabilizado 1 strike a sua conta, Atente-se! ao alcançar 5 strikes sua conta será banida!'
                ));
    END IF;

    IF old.status_reserva = 'Em andamento' AND NEW.status_reserva = 'Cancelada' THEN
        SELECT tb_usuariocomum.id_usuarioComum
        INTO v_id_usuariocomum
        FROM tb_usuariocomum
                 INNER JOIN tb_pessoa ON tb_usuariocomum.id_usuarioComum = tb_pessoa.id_pessoa
                 INNER JOIN tb_chamado ON tb_chamado.id_usuarioComum = tb_usuariocomum.id_usuarioComum
        WHERE tb_chamado.id_chamado = old.id_chamado
        LIMIT 1;

        UPDATE tb_usuariocomum
        SET usuariocomum_strikes = usuariocomum_strikes + 1
        WHERE id_usuarioComum = v_id_usuariocomum;

        IF NOT EXISTS (SELECT 1
                       FROM tb_notifica_solicitante
                       WHERE id_usuariocomum = v_id_usuariocomum
                         AND id_chamado = old.id_chamado) THEN
            INSERT INTO tb_notifica_solicitante (id_usuariocomum,
                                                 id_chamado,
                                                 mensagem)
            VALUES (v_id_usuariocomum,
                    old.id_chamado,
                    CONCAT('Chamado número ', old.id_chamado,
                           ' cancelado com sucesso! O chamado que você cancelou havia sido reservado, logo,
                           sua conta receberá 1 strike por interromper uma coleta!'));
        END IF;

        INSERT INTO tb_notifica_coletor (id_coletor,
                                         id_chamado_reservado,
                                         mensagem)
        VALUES (v_id_coletor,
                OLD.id_chamado_reservado,
                CONCAT(
                        'ATENÇÃO COLETOR(A) ', v_nome_coletor,
                        ', infelizmente o chamado número ', old.id_chamado,
                        ' foi cancelado pelo solicitante!. Mas não desista! siga com suas reservas. '
                ));
    END IF;
END //
DELIMITER ;

use ecofinder;
CREATE VIEW vw_verendereco AS -- view que mostra o endereço do usuario
SELECT tb_pessoa.email                                                        AS email,
       CONCAT(rua, ", ", numerocasa, ", ", bairro, ", ", cidade, "-", estado) AS endereco_format,
       tb_endereco.id_endereco
FROM tb_endereco
         INNER JOIN tb_pessoa ON tb_endereco.id_pessoa_endereco = tb_pessoa.id_pessoa;


CREATE VIEW vw_lat_log_col AS -- essa view pra pegar latitude e longitude do coletor
SELECT email, latitude, longitude
FROM tb_endereco
         INNER JOIN tb_pessoa ON id_pessoa_endereco = id_pessoa;

CREATE VIEW vw_lat_log_user AS -- alteracao matheus
SELECT id_endereco, latitude, longitude, tipo
FROM tb_endereco
         INNER JOIN tb_pessoa on tb_endereco.id_pessoa_endereco = tb_pessoa.id_pessoa
         INNER JOIN tb_usuariocomum on tb_pessoa.id_pessoa = tb_usuarioComum.id_usuarioComum
         INNER JOIN tb_chamado on tb_usuariocomum.id_usuarioComum = tb_chamado.id_usuarioComum
         INNER JOIN tb_disponibilidade on tb_chamado.id_chamado = tb_disponibilidade.id_chamado
         INNER JOIN tb_chamado_material tcm on tb_chamado.id_chamado = tcm.id_chamado
         INNER JOIN tb_material on tcm.id_material = tb_material.id_material
WHERE tb_disponibilidade.status = "Disponível";

CREATE VIEW vw_mostrar_material_chamado as -- alteracao matheus
SELECT id_endereco, tipo
from tb_endereco te
         INNER JOIN tb_pessoa tp on te.id_pessoa_endereco = tp.id_pessoa
         INNER JOIN tb_chamado tc on tc.id_usuarioComum = tp.id_pessoa
         INNER JOIN tb_chamado_material tcm on tc.id_chamado = tcm.id_chamado
         INNER JOIN tb_material tm on tcm.id_material = tm.id_material;


CREATE VIEW vw_quant_chamados AS
SELECT *
from tb_disponibilidade
WHERE status = "Disponível";


CREATE VIEW vw_ver_chamado_reserva_coletor as
SELECT tb_chamado.id_chamado,
       tb_pessoa.nome,
       tb_chamados_reservados.id_coletor,
       CONCAT(rua, ", ", numerocasa, ", ", bairro, ", ", cidade, "-", estado) as endereco_format,
       data_chamado,
       tb_chamado.data_expiracao,
       status_reserva,
       tipo,
       tb_chamado_material.qtde_unitaria,
       tb_chamado_material.kilograma,
       tb_chamado_material.tamanho_material
from tb_chamado
         INNER JOIN tb_chamado_material on tb_chamado.id_chamado = tb_chamado_material.id_chamado
         INNER JOIN tb_usuariocomum tu on tb_chamado.id_usuarioComum = tu.id_usuarioComum
         INNER JOIN tb_material on tb_chamado_material.id_material = tb_material.id_material
         INNER JOIN tb_pessoa on tu.id_usuarioComum = tb_pessoa.id_pessoa
         INNER JOIN tb_endereco te on tb_pessoa.id_pessoa = te.id_pessoa_endereco
         INNER JOIN tb_disponibilidade td on tb_chamado.id_chamado = td.id_chamado
         INNER JOIN tb_chamados_reservados on tb_chamados_reservados.id_chamado = tb_chamado.id_chamado;


create view vw_ver_chamado_reserva_usuario as
SELECT tb_chamado.id_chamado,
       tb_pessoa.nome,
       tb_pessoa.id_pessoa,
       CONCAT(rua, ", ", numerocasa, ", ", bairro, ", ", cidade, "-", estado) as endereco_format,
       data_chamado,
       tb_chamado.data_expiracao,
       status,
       tipo,
       tb_chamado_material.qtde_unitaria,
       tb_chamado_material.kilograma,
       tb_chamado_material.tamanho_material
from tb_chamado
         INNER JOIN tb_chamado_material on tb_chamado.id_chamado = tb_chamado_material.id_chamado
         INNER JOIN tb_usuariocomum tu on tb_chamado.id_usuarioComum = tu.id_usuarioComum
         INNER JOIN tb_material on tb_chamado_material.id_material = tb_material.id_material
         INNER JOIN tb_pessoa on tu.id_usuarioComum = tb_pessoa.id_pessoa
         INNER JOIN tb_endereco te on tb_pessoa.id_pessoa = te.id_pessoa_endereco
         INNER JOIN tb_disponibilidade td on tb_chamado.id_chamado = td.id_chamado;

 create view vw_ver_dados_pessoa as
    SELECT id_pessoa, nome, email, genero, cep, rua, bairro, cidade, numerocasa, estado from tb_pessoa
    INNER JOIN tb_endereco te on tb_pessoa.id_pessoa = te.id_pessoa_endereco;

DELIMITER //
create EVENT call_prc_chamado_expirado_AND_reserva_expirada
    ON SCHEDULE EVERY 30 second
        STARTS CURRENT_TIMESTAMP
    DO
    BEGIN
        call chamado_expirado_AND_reserva_expirada();
    end //
DELIMITER ;

DELIMITER //
create EVENT call_banimento
    ON SCHEDULE EVERY 30 second
        STARTS CURRENT_TIMESTAMP
    DO
    BEGIN
        call PR_BANIMENTO();
    end //
DELIMITER ;

delimiter //
create function f_identificar_tipo_conta(p_email varchar(250), p_senha varchar(100))
    returns int
    deterministic
begin
    if EXISTS (select 1
               from tb_pessoa
               where email = p_email
                 and senha = p_senha
                 AND id_pessoa IN (select id_coletor from tb_coletor))
    then
        return 1;
    elseif EXISTS (select 1
                   from tb_pessoa
                   where email = p_email
                     and senha = p_senha
                     AND id_pessoa IN (select id_usuarioComum from tb_usuariocomum))
    then
        return 2;
    else
        return null;
    end if;
end //
delimiter ;

-- funcao para identificar o id do usuario comum apartir do email
delimiter //
create function f_identificar_id_conta(f_email varchar(250))
    returns int
    deterministic
begin
    declare id_pessoa_local int;

    select id_pessoa
    into id_pessoa_local
    from tb_pessoa
    where email = f_email
    limit 1;

    return id_pessoa_local;


end//
delimiter ;


DELIMITER //
CREATE FUNCTION F_CANCEL_CHAMADO(p_id_chamado INT)
    RETURNS BOOL
    DETERMINISTIC
BEGIN
    IF (SELECT COUNT(*)
        FROM tb_chamado
                 INNER JOIN tb_disponibilidade ON tb_disponibilidade.id_chamado = tb_chamado.id_chamado
        WHERE tb_disponibilidade.id_chamado = p_id_chamado
          AND (status = 'Disponivel' OR status = 'Reservado')) = 0
    THEN
        RETURN FALSE;
    END IF;

    UPDATE tb_disponibilidade
    SET STATUS = 'Cancelado'
    WHERE id_chamado = p_id_chamado
      AND STATUS IN ('Disponivel', 'Reservado');

    IF EXISTS (SELECT 1
               FROM tb_chamado
                        INNER JOIN tb_chamados_reservados ON tb_chamados_reservados.id_chamado = tb_chamado.id_chamado
               WHERE tb_chamados_reservados.id_chamado = p_id_chamado
               LIMIT 1) THEN
        UPDATE tb_chamados_reservados
        SET status_reserva = 'Cancelada'
        WHERE id_chamado = p_id_chamado
          AND status_reserva <> 'Cancelada';
    END IF;

    RETURN TRUE;
END //
DELIMITER ;


DELIMITER //
create FUNCTION F_CHECK_ENDERECO_REPETIDO(P_CEP varchar(10), P_numerocasa varchar(10))
    RETURNS BOOL
    DETERMINISTIC
BEGIN
    if exists(SELECT 1 from tb_endereco where cep = P_CEP and numerocasa = P_numerocasa)
    then
        return true;
    else
        return false;
    end if;
END //
DELIMITER ;


 DELIMITER //
CREATE PROCEDURE proc_atualizaPerfil(
    IN novo_nome VARCHAR(250),
    IN novo_email VARCHAR(250),
    IN novo_senha VARCHAR(250),
    IN novo_genero VARCHAR(20),
    IN antigo_email VARCHAR(250))
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        SELECT 0;
    END;

    START TRANSACTION;

    IF EXISTS (SELECT 1 FROM tb_pessoa WHERE email = antigo_email) THEN
        UPDATE tb_pessoa
        SET nome = novo_nome,
            email = novo_email,
            senha = novo_senha,
            genero = novo_genero
        WHERE email = antigo_email;

        COMMIT;
        SELECT 1;
    ELSE
        ROLLBACK;
        SELECT 0;
    END IF;
END //
DELIMITER ;


delimiter //
CREATE PROCEDURE pc_nivel(p_id_coletor int)
BEGIN
    UPDATE tb_coletor SET nivel = nivel+1
    WHERE quantidade_coletas % 10 = 0 AND p_id_coletor = id_coletor;

end//
delimiter ;


DELIMITER //
CREATE PROCEDURE PR_BANIMENTO()
BEGIN
    UPDATE tb_pessoa
        inner join tb_coletor on tb_coletor.id_coletor = tb_pessoa.id_pessoa
    set situacao_conta = 'INATIVA'
    where tb_coletor.coletor_strikes = 5;

    UPDATE tb_pessoa
        inner join tb_usuariocomum on tb_usuariocomum.id_usuarioComum = tb_pessoa.id_pessoa
    set situacao_conta = 'INATIVA'
    where tb_usuariocomum.usuariocomum_strikes = 5;
END//
DELIMITER ;

call PR_BANIMENTO();

DELIMITER //
CREATE PROCEDURE DELETA_CONTA(IN P_EMAIL varchar(250), OUT RESUL boolean)
BEGIN
    DECLARE v_id_chamado INT;
    DECLARE v_id_usuario INT;

    LABEL_BLOCO:
    BEGIN
        SET v_id_usuario = f_identificar_id_conta(P_EMAIL);

        IF v_id_usuario IS NULL THEN
            SET RESUL = FALSE;
            LEAVE LABEL_BLOCO;

        ELSE
            IF v_id_usuario IN (SELECT id_coletor FROM tb_coletor) THEN

                IF EXISTS (SELECT 1
                           FROM tb_chamados_reservados
                           WHERE id_coletor = v_id_usuario
                           LIMIT 1) THEN
                    SELECT id_chamado
                    INTO v_id_chamado
                    FROM tb_chamados_reservados
                    WHERE id_coletor = v_id_usuario
                    LIMIT 1;

                    CALL PR_CANCELANDO_RESERVA(v_id_chamado, @resultado);

                    IF @resultado = TRUE THEN
                        UPDATE tb_pessoa
                        SET situacao_conta = 'INATIVA'
                        WHERE id_pessoa = v_id_usuario;
                        SET RESUL = TRUE;
                    ELSE
                        SET RESUL = FALSE;
                        LEAVE LABEL_BLOCO;
                    END IF;
                ELSE
                    -- Não tem reserva, só inativa
                    UPDATE tb_pessoa
                    SET situacao_conta = 'INATIVA'
                    WHERE id_pessoa = v_id_usuario;
                    SET RESUL = TRUE;
                END IF;

            ELSEIF v_id_usuario IN (SELECT id_usuarioComum FROM tb_usuariocomum) THEN

                IF EXISTS (SELECT 1
                           FROM tb_chamado
                           WHERE id_usuarioComum = v_id_usuario
                           LIMIT 1) THEN
                    SELECT id_chamado
                    INTO v_id_chamado
                    FROM tb_chamado
                    WHERE id_usuarioComum = v_id_usuario
                    LIMIT 1;

                    IF F_CANCEL_CHAMADO(v_id_chamado) = TRUE THEN
                        UPDATE tb_pessoa
                        SET situacao_conta = 'INATIVA'
                        WHERE id_pessoa = v_id_usuario;
                        SET RESUL = TRUE;
                    ELSE
                        SET RESUL = FALSE;
                        LEAVE LABEL_BLOCO;
                    END IF;
                ELSE
                    -- Não tem chamado, só inativa
                    UPDATE tb_pessoa
                    SET situacao_conta = 'INATIVA'
                    WHERE id_pessoa = v_id_usuario;
                    SET RESUL = TRUE;
                END IF;
            END IF;
        END IF;
    END LABEL_BLOCO;
END //
DELIMITER ;


DELIMITER //
CREATE PROCEDURE p_confirmar_coleta(
    IN p_id_chamado_reservado INT,
    IN p_tipo_usuario ENUM ('COLETOR', 'SOLICITANTE')
)
BEGIN
    DECLARE v_id_chamado INT;
    DECLARE v_id_coletor INT;
    DECLARE v_id_solicitante INT;

    -- Obter IDs relacionados
    SELECT id_chamado, id_coletor
    INTO v_id_chamado, v_id_coletor
    FROM tb_chamados_reservados
    WHERE id_chamado_reservado = p_id_chamado_reservado;

    SELECT id_usuarioComum
    INTO v_id_solicitante
    FROM tb_chamado
    WHERE id_chamado = v_id_chamado;

    -- Atualizar confirmação conforme tipo de usuário
    IF p_tipo_usuario = 'COLETOR' THEN
        UPDATE tb_chamados_reservados
        SET confirmacao_coletor = TRUE
        WHERE id_chamado_reservado = p_id_chamado_reservado;

        -- Notificar solicitante
        INSERT INTO tb_notifica_solicitante(id_usuariocomum, id_chamado, mensagem)
        VALUES (v_id_solicitante, v_id_chamado, 'O coletor confirmou a coleta. Por favor, confirme o recebimento.');

    ELSEIF p_tipo_usuario = 'SOLICITANTE' THEN
        UPDATE tb_chamados_reservados
        SET confirmacao_solicitante = TRUE
        WHERE id_chamado_reservado = p_id_chamado_reservado;
    END IF;

    -- Verificar se ambas as confirmações foram realizadas
    IF EXISTS (SELECT 1
               FROM tb_chamados_reservados
               WHERE id_chamado_reservado = p_id_chamado_reservado
                 AND confirmacao_coletor IS TRUE
                 AND confirmacao_solicitante IS TRUE) THEN
        UPDATE tb_chamados_reservados
        SET status_reserva = 'Concluida'
        WHERE id_chamado_reservado = p_id_chamado_reservado;

        UPDATE tb_disponibilidade
        SET status = 'Concluido'
        WHERE  id_chamado = v_id_chamado;

        CALL pc_nivel(v_id_coletor);

        -- Notificar coletor
        INSERT INTO tb_notifica_coletor(id_coletor, id_chamado_reservado, mensagem)
        VALUES (v_id_coletor, p_id_chamado_reservado, 'Coleta confirmada por ambas as partes. Processo concluído.');
    END IF;
END //
DELIMITER ;


DELIMITER //
CREATE PROCEDURE PR_CANCELANDO_RESERVA(
    IN P_ID_CHAMADO INT,
    OUT RESULT BOOL
)
fim:
BEGIN
    DECLARE v_id_usuariocomum INT;
    DECLARE v_id_coletor INT;
    DECLARE v_id_chamado_reservado INT;

    -- vendo se o chamado recebido como parametro existe
    IF NOT EXISTS (SELECT 1
                   FROM tb_chamados_reservados
                   WHERE id_chamado = P_ID_CHAMADO
                     AND status_reserva = 'Em andamento') THEN
        SET RESULT = FALSE;
        LEAVE fim;
    END IF;

    START TRANSACTION;


    SELECT id_coletor, id_chamado_reservado
    INTO v_id_coletor, v_id_chamado_reservado
    FROM tb_chamados_reservados
    WHERE id_chamado = P_ID_CHAMADO
      AND status_reserva = 'Em andamento'
    LIMIT 1
    FOR
    UPDATE;
    -- ESSE FOR UPDATE É PARA EVITAR CONCORRENCIA, ele vai travar a linha para que apenas uma transacao seja realizada por vez

    -- verificacao se a reserva existe so pra ter certeza
    IF v_id_chamado_reservado IS NULL THEN
        ROLLBACK;
        SET RESULT = FALSE;
        LEAVE fim;
    END IF;


    UPDATE tb_chamados_reservados
    SET status_reserva = 'Cancelada'
    WHERE id_chamado_reservado = v_id_chamado_reservado;




    INSERT INTO tb_notifica_coletor (id_coletor, id_chamado_reservado, mensagem)
    VALUES (v_id_coletor,
            v_id_chamado_reservado,
            CONCAT('A reserva do chamado ', P_ID_CHAMADO, ' foi cancelada.'));


    UPDATE tb_disponibilidade
    SET status = 'Disponivel'
    WHERE id_chamado = P_ID_CHAMADO
      AND status = 'Reservado';


    UPDATE tb_chamado
    SET data_expiracao = NOW() + INTERVAL 1 DAY
    WHERE id_chamado = P_ID_CHAMADO;


    SELECT id_usuariocomum
    INTO v_id_usuariocomum
    FROM tb_chamado
    WHERE id_chamado = P_ID_CHAMADO;

    -- Notifica solicitante
    INSERT INTO tb_notifica_solicitante (id_usuariocomum, id_chamado, mensagem)
    VALUES (v_id_usuariocomum,
            P_ID_CHAMADO,
            CONCAT(
                    'A reserva do seu chamado número ', P_ID_CHAMADO,
                    ' foi cancelada. Ele está disponível novamente e com nova data de expiração!'
            ));

    SET RESULT = TRUE;
    COMMIT;
END fim //
DELIMITER ;

delimiter //
CREATE procedure proc_realizar_chamado(
    p_email varchar(250),
    p_tipo_material varchar(20),
    p_kilograma decimal(10, 2),
    p_qtde_unitaria int,
    p_tamanho varchar(10)
)
BLOCO :
begin
    declare RESULTADO BOOLEAN;
    declare v_chamado_id int;
    declare v_material_id int;
    DECLARE ID_USUARIOCOMUM INT;
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
        BEGIN
            ROLLBACK;
            SET RESULTADO = FALSE;
        END;

    SET RESULTADO = FALSE;
    SET ID_USUARIOCOMUM = f_identificar_id_conta(p_email);

    SELECT id_material
    INTO v_material_id
    FROM tb_material
    WHERE tipo = p_tipo_material
    LIMIT 1;

    if exists (SELECT 1
               FROM tb_chamado
                        inner join tb_chamado_material on tb_chamado_material.id_chamado = tb_chamado.id_chamado
               where tb_chamado.id_usuariocomum = ID_USUARIOCOMUM-- usando a funcao para encontrar o id do solicitante
                 AND id_material = v_material_id
                 AND kilograma = p_kilograma
                 AND tamanho_material = p_tamanho
                 AND qtde_unitaria = p_qtde_unitaria)
    THEN
        SET RESULTADO = FALSE;
        LEAVE BLOCO;
    END IF;


    START TRANSACTION;
    insert into tb_chamado(id_usuariocomum)
    values (ID_USUARIOCOMUM); -- usando a funcao para encontrar o id do solicitante

    set v_chamado_id = last_insert_id();

    insert into tb_chamado_material (id_chamado, id_material, qtde_unitaria, kilograma, tamanho_material)
    values (v_chamado_id, v_material_id, p_qtde_unitaria, p_kilograma, p_tamanho);

    INSERT INTO tb_disponibilidade (id_chamado, status) VALUES (v_chamado_id, 'Disponível');
    COMMIT;
    SET RESULTADO = TRUE;
    SELECT RESULTADO;
END BLOCO//
delimiter ;


delimiter //
CREATE procedure proc_realizar_reserva(p_email varchar(250),
                                       p_id_chamado int,
                                       in p_previsao_coleta VARCHAR(10),
                                       out RESULTADO bool)
BLOCO :
begin

    DECLARE v_id_coletor INT;
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
        BEGIN
            ROLLBACK;
            SET RESULTADO = FALSE;
        END;

    SET RESULTADO = FALSE;
    SET v_id_coletor = f_identificar_id_conta(p_email);

    /*verficando de o chamdo existe  E -*/
    /*verificando se ele o chamado ja esta reservado*/
    /**verficanso se a previsao fornecida é valida*/

    IF NOT EXISTS (SELECT 1 FROM tb_chamado WHERE id_chamado = p_id_chamado) OR
       v_id_coletor IS NULL OR
       exists (SELECT 1
               FROM tb_chamados_reservados
               WHERE id_chamado = p_id_chamado
                 AND status_reserva = 'Em andamento') OR
       p_previsao_coleta not in ('Manhã', 'Tarde', 'Noite') OR
       exists(SELECT id_chamado
              from tb_disponibilidade
              where p_id_chamado = id_chamado
                AND status = 'Cancelado'
              limit 1)
    THEN
        SET RESULTADO = FALSE;
        LEAVE BLOCO;
    END IF;


    START TRANSACTION;
    insert into tb_chamados_reservados(id_chamado,
                                       id_coletor,
                                       previsao_coleta,
                                       status_reserva)
    values (p_id_chamado,
            v_id_coletor,
            p_previsao_coleta,
            'Em andamento');
    IF ROW_COUNT() = 1 THEN
        COMMIT;
        SET RESULTADO = TRUE;
    ELSE
        ROLLBACK;

    END IF;

END BLOCO//
delimiter ;


DELIMITER //
create procedure chamado_expirado_AND_reserva_expirada()
BEGIN

    UPDATE tb_disponibilidade
        INNER JOIN tb_chamado ON tb_chamado.id_chamado = tb_disponibilidade.id_chamado
    SET tb_disponibilidade.status = 'Expirado'
    WHERE tb_chamado.data_expiracao < NOW()
      AND tb_disponibilidade.status = 'Disponivel';


    INSERT INTO tb_notifica_solicitante(id_usuariocomum,
                                        id_chamado,
                                        mensagem)
    SELECT tb_chamado.id_usuarioComum,
           tb_chamado.id_chamado,
           CONCAT(
                   'ATENÇÃO! Seu chamado de número ',
                   tb_chamado.id_chamado,
                   ' expirou sem ser reservado por nenhum coletor. Sinta-se à vontade para criar um novo chamado a qualquer momento.'
           )
    FROM tb_chamado
             INNER JOIN tb_disponibilidade ON tb_disponibilidade.id_chamado = tb_chamado.id_chamado
    WHERE tb_disponibilidade.status = 'Expirado'
      AND NOT EXISTS (SELECT 1
                      FROM tb_notifica_solicitante
                      WHERE tb_notifica_solicitante.id_chamado = tb_chamado.id_chamado
                        AND mensagem LIKE CONCAT('%', tb_chamado.id_chamado, ' expirou%'));


    UPDATE tb_chamados_reservados
    SET status_reserva = 'Expirada'
    WHERE data_expiracao_reserva < NOW()
      AND status_reserva = 'Em andamento';


    UPDATE tb_disponibilidade
        INNER JOIN tb_chamados_reservados ON tb_chamados_reservados.id_chamado = tb_disponibilidade.id_chamado
    SET tb_disponibilidade.status = 'Disponivel'
    WHERE tb_chamados_reservados.status_reserva = 'Expirada'
      AND tb_disponibilidade.status = 'Reservado';


    UPDATE tb_chamado as c
        INNER JOIN tb_chamados_reservados as cr ON cr.id_chamado = c.id_chamado
    SET c.data_expiracao = NOW() + INTERVAL 1 DAY
    WHERE cr.status_reserva = 'Expirada'
      AND NOT EXISTS (SELECT 1
                      FROM tb_notifica_coletor as n
                      WHERE n.id_coletor = cr.id_coletor
                        AND n.mensagem LIKE CONCAT('%', c.id_chamado, ' expirou%'));

    -- A NOTIFICACAO PARA O COLETOR ESTA EM OUTRO TRIGGER PARA NAO DEIXAR O PROCEDIMENTO COM TANTAS INSTRUCOES

END //
DELIMITER ;

call chamado_expirado_AND_reserva_expirada();

-- Consulta para exibir os chamados no momento da reserva !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!


delimiter //
create procedure pc_ver_chamados(pc_email varchar(250), pc_linha int, pc_material varchar(20))
begin

    declare pc_id int;

    select id_pessoa
    into pc_id
    from tb_pessoa
    where email = pc_email;

    IF pc_material = "N"
    then
        SELECT tb_chamado.id_chamado,
               nome                                                                   as 'Nome do solicitante',
               CONCAT(rua, ", ", numerocasa, ", ", bairro, ", ", cidade, "-", estado) as 'Endereco',
               tipo,
               qtde_unitaria                                                          as 'quantidade',
               tamanho_material                                                       as 'tamanho',
               CONCAT(ROUND(ST_Distance_Sphere(
                                    POINT(
                                            (SELECT longitude
                                             FROM tb_endereco
                                             WHERE id_pessoa_endereco = tb_usuariocomum.id_usuarioComum),
                                            (SELECT latitude
                                             FROM tb_endereco
                                             WHERE id_pessoa_endereco = tb_usuariocomum.id_usuarioComum)
                                    ),
                                    POINT(
                                            (SELECT longitude FROM tb_endereco WHERE id_pessoa_endereco = pc_id), -- nessa parte deve se usar a funcao f_identificar_a_conta para conseguir achar o id do coeltor que esta buscando um chamado para reservar
                                            (SELECT latitude FROM tb_endereco WHERE id_pessoa_endereco = pc_id)
                                    )
                            ) / 1000, 1), ' KM')                                      AS 'Distancia'
        FROM tb_pessoa
                 INNER JOIN tb_endereco ON tb_endereco.id_pessoa_endereco = tb_pessoa.id_pessoa
                 INNER JOIN tb_usuariocomum ON tb_usuariocomum.id_usuarioComum = tb_pessoa.id_pessoa
                 INNER JOIN tb_chamado ON tb_chamado.id_usuarioComum = tb_usuariocomum.id_usuarioComum
                 INNER JOIN tb_chamado_material ON tb_chamado_material.id_chamado = tb_chamado.id_chamado
                 INNER JOIN tb_material ON tb_material.id_material = tb_chamado_material.id_material
                 INNER JOIN tb_disponibilidade ON tb_disponibilidade.id_chamado = tb_chamado.id_chamado
        WHERE tb_disponibilidade.status = 'Disponivel'

        ORDER BY ROUND(ST_Distance_Sphere(
                               POINT(
                                       (SELECT longitude
                                        FROM tb_endereco
                                        WHERE id_pessoa_endereco = tb_usuariocomum.id_usuarioComum),
                                       (SELECT latitude
                                        FROM tb_endereco
                                        WHERE id_pessoa_endereco = tb_usuariocomum.id_usuarioComum)
                               ),
                               POINT(
                                       (SELECT longitude FROM tb_endereco WHERE id_pessoa_endereco = pc_id),
                                       (SELECT latitude FROM tb_endereco WHERE id_pessoa_endereco = pc_id)
                               )
                       ), 1) ASC
        LIMIT pc_linha,1;
    ELSE
        SELECT tb_chamado.id_chamado,
               nome                                                                   as 'Nome do solicitante',
               CONCAT(rua, ", ", numerocasa, ", ", bairro, ", ", cidade, "-", estado) as 'Endereco',
               tipo,
               qtde_unitaria                                                          as 'quantidade',
               tamanho_material                                                       as 'tamanho',
               CONCAT(ROUND(ST_Distance_Sphere(
                                    POINT(
                                            (SELECT longitude
                                             FROM tb_endereco
                                             WHERE id_pessoa_endereco = tb_usuariocomum.id_usuarioComum),
                                            (SELECT latitude
                                             FROM tb_endereco
                                             WHERE id_pessoa_endereco = tb_usuariocomum.id_usuarioComum)
                                    ),
                                    POINT(
                                            (SELECT longitude FROM tb_endereco WHERE id_pessoa_endereco = pc_id), -- nessa parte deve se usar a funcao f_identificar_a_conta para conseguir achar o id do coeltor que esta buscando um chamado para reservar
                                            (SELECT latitude FROM tb_endereco WHERE id_pessoa_endereco = pc_id)
                                    )
                            ) / 1000, 1), ' KM')                                      AS 'Distancia'
        FROM tb_pessoa
                 INNER JOIN tb_endereco ON tb_endereco.id_pessoa_endereco = tb_pessoa.id_pessoa
                 INNER JOIN tb_usuariocomum ON tb_usuariocomum.id_usuarioComum = tb_pessoa.id_pessoa
                 INNER JOIN tb_chamado ON tb_chamado.id_usuarioComum = tb_usuariocomum.id_usuarioComum
                 INNER JOIN tb_chamado_material ON tb_chamado_material.id_chamado = tb_chamado.id_chamado
                 INNER JOIN tb_material ON tb_material.id_material = tb_chamado_material.id_material
                 INNER JOIN tb_disponibilidade ON tb_disponibilidade.id_chamado = tb_chamado.id_chamado
        WHERE tb_disponibilidade.status = 'Disponivel'

        ORDER BY (tipo = pc_material) DESC,
                 ROUND(ST_Distance_Sphere(
                               POINT(
                                       (SELECT longitude
                                        FROM tb_endereco
                                        WHERE id_pessoa_endereco = tb_usuariocomum.id_usuarioComum),
                                       (SELECT latitude
                                        FROM tb_endereco
                                        WHERE id_pessoa_endereco = tb_usuariocomum.id_usuarioComum)
                               ),
                               POINT(
                                       (SELECT longitude FROM tb_endereco WHERE id_pessoa_endereco = pc_id),
                                       (SELECT latitude FROM tb_endereco WHERE id_pessoa_endereco = pc_id)
                               )
                       ), 1) ASC
        LIMIT pc_linha,1;

    end if;
end //
delimiter ;

DELIMITER //
    CREATE PROCEDURE pc_relatorio_coletor(pc_email VARCHAR(250))
    BEGIN
        DECLARE v_id_coletor INT;

        SELECT f_identificar_id_conta(pc_email) INTO v_id_coletor;

        SELECT tb_coletor.id_coletor, nivel, quantidade_coletas, count(id_chamado_reservado) FROM tb_coletor
            INNER JOIN tb_chamados_reservados on tb_coletor.id_coletor = tb_chamados_reservados.id_coletor
            WHERE status_reserva = 'Em andamento' AND tb_coletor.id_coletor = v_id_coletor;
    END //
DELIMITER ;
