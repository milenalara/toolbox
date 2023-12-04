-- DROP DATABASE toolbox;

USE `toolbox`;

INSERT INTO toolbox.usuario (nome, cpf, password, email)
VALUES
	("Fernanda Torres", "12345678901", "Testing123", "fernandatores@email1243.com"),
	("Tony Ramos", "12345678902", "Testing123", "tony@email1243.com"),
	("Fernanda Montenegro", "12345678903", "Testing123", "fernandamontenegro@email1243.com"),
	("Antônio Fagundes", "03215879451", "Testing123", "antonio@email1243.com"),
	("Wagner Moura","78945612345", "Testing123", "wagner@email1243.com"),
	("Pedro Pascal", "14785236978", "Testing123", "pedro@email1243.com"),
	("Juliana Paes","12355546789", "Testing123", "juliana@email1243.com"),
    ("Marjorie Estiano","01234567891", "Testing123", "marjorie@email1243.com"),
	("Tom Hanks", "02312345678", "Testing123", "tom@email1243.com"),
	("Merryl Streep","02355546789", "Testing123", "merryl@email1243.com");

INSERT INTO toolbox.categoria (nome)
VALUES
	("Lar"),
	("Eletrônicos"),
	("Música e Hobbies"),
    ("Esportes e lazer"),
	("Infantil"),
	("Pets"),
    ("Moda"),
    ("Beleza"),
    ("Agro e Indústria");

-- INSERT INTO toolbox.categoria (nome, id_categoria_mae)
-- VALUES
--     -- subcategorias "Lar":
-- 	("Móveis", 1),
-- 	("Eletrodomésticos", 1),
-- 	("Decoração", 1),
-- 	("Eletroportáteis", 1),
-- 	("Ferramentas", 1),
--     -- subcategorias "Eletrônicos":
-- 	("Computadores e acessórios", 2),
-- 	("Áudio, TV, vídeo e fotografia", 2),
--     ("Videogames", 2),
--     -- subcategoria "Música e Hobbies"
--     ("Livros e revistas", 3),
--     ("Instrumentos musicais", 3),
--     ("CDs e DVDs", 3),
--     ("Antiguidades", 3),
--     -- subcategoria "Esportes e lazer"
--     ("Ciclismo", 4),
--     ("Ginástica", 4),
--     ("Esportes", 4),
--     -- subcategoria "Infantil"
--     ("Brinquedos", 5),
--     ("Carrinhos e cadeirinhas", 5),
--     ("Berço e quarto infantil", 5),
--     -- subcategoria "Pets"
--     ("Comedouros e bebedouros", 6),
--     ("Aquário e acessórios", 6),
--     ("Gatos", 6),
--     ("Cachorros", 6),
--     ("Roedores", 6),
--     ("Cavalos", 6),
--     -- subcategoria "Moda"
--     ("Roupas", 7),
--     ("Calçados", 7),
--     ("Acessórios", 7),
--     ("Bolsas", 7),
--     ("Bijuterias", 7),
--     -- subcategoria "Beleza"
--     ("Cabelo", 8),
--     ("Skincare", 8),
--     ("Maquiagem", 8),
--     -- subcategoria "Agro e Indústria"
--     ("Máquinas para produção industrial", 9),
--     ("Máquinas para construção", 9),
--     ("Tratores e máquinas agrícolas", 9);

INSERT INTO toolbox.produto (nome, condicao, marca, descricao)
VALUES
    ("Faqueiro Tramontina Búzios Em Aço Inox Com Detalhe 24 Peças", "Ótimo", "Tramontina", "24 Peças. Produzido totalmente em aço inox, o faqueiro além de ser resistente e durável, deixa a composição da sua mesa ainda mais especial, pois as peças que compõem o jogo possuem um lindo acabamento, garantindo um charme a mais para a refeição."),
    ("Caixa De Som Amplificada Multiuso Frahm - Bluetooth 300w", "Bom", "Frahm", "O Frahm CMF-300 oferece um som natural, com grande clareza e precisão, que é uniformemente disperso. Um alto-falante que garante potência e qualidade por igual na reprodução de conteúdos multimídia."),
    ("Caixa Harry Potter - Edição Premium, de Rowling, J. K.", "Bom", "Rocco", "Todos os livros da série neste box. Capa mole, em Português"),
    ("Bicicleta 29 Alumínio 21v Câmbios Shimano Freio À Disco Krs", "Regular", "KRS", "A BICICLETA É MONTADA E ENGRAXADA , PORÉM POR MOTIVO DE ACOMODAÇÃO NA EMBALAGEM DE TRANSPORTE, SÃO. RETIRADOS OS PEDAIS, SELIM, GUIDÃO E A RODA DIANTEIRA. A INSTALAÇÃO É DE RESPONSABILIDADE DO CLIENTE,"),
    ("Relógio Champion Masculino Aço Prata Azul", "Ótimo", "Champion", "Características
Composição do Vidro: Cristal Mineral
Material da Caixa: Aço Inox
Material da Pulseira: Aço Inox
Modelo : Analógico
Mecanismo: Quartz
Alimentação: Bateria
Resistência à Água: 5 ATM
Diâmetro da Caixa: 4,2 cm
Funções Especiais
Calendário"),
	("Body Bebe Kit 9 Peças Menina Ou Menino", "Bom", "Canoah Confecção", "3 Kits de Body Bebe
Cada kit tem 3 peças totalizando 9 peças.
Lindas roupinhas de bebê para menina ou menino, peças de excelente qualidade confortáveis e com muito estilo. Surpreenda-se")
;

-- INSERT INTO categorias_produtos (id_produto, id_categoria)
-- VALUES
-- 	(1, 1),
--     (1, 10),
--     (2, 1),
--     (3, 2),
--     (3, 16),
--     (4, 3),
--     (4, 18),
--     (5, 4),
--     (5, 22),
--     (6, 7),
--     (6, 36),
--     (7, 5),
--     (7, 7),
--     (7, 34)
-- ;