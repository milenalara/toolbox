-- Dados pessoais, de endereço e de contato do usuario
SELECT
	u.nome AS "Nome",
	u.cpf AS "CPF",
	u.email AS "Email",
	e.logradouro AS "Logradouro",
	e.numero AS "Nº",
	e.bairro AS "Bairro",
	t.codigo_area AS "DDD",
	t.numero AS "Telefone"
FROM toolbox.usuario AS u
JOIN toolbox.telefone AS t ON t.id_usuario = u.id
LEFT JOIN toolbox.endereco AS e ON toolbox.produto.id_usuario = u.id;

ALTER TABLE toolbox.produto ADD preco DECIMAL(10,2);

-- Selecionar produtos
SELECT
	p.nome,
	p.condicao,
	p.marca,
	p.descricao,
	p.preco,
	c.nome_categoria AS "categoria"
FROM toolbox.produto AS p
JOIN toolbox.categorias_de_produtos AS cp ON cp.id_produto = p.id
JOIN toolbox.categoria AS c ON cp.id_categoria = c.id;

-- Selecionar um produto
SELECT
	p.nome,
	p.condicao,
	p.marca,
	p.descricao,
	p.preco,
	c.nome AS "categoria"
FROM toolbox.produto AS p
JOIN toolbox.categorias_de_produtos AS cp ON cp.id_produto = p.id
JOIN toolbox.categoria AS c ON cp.id_categoria = c.id
WHERE p.id = 1;

-- Inserir produtos
INSERT INTO toolbox.produto (nome, condicao, marca, descricao, preco)
VALUES (
	"{produto.Nome}",
	"{produto.Condicao}",
	"{produto.Marca}",toolbox.emprestimo
	"{produto.Descricao}",
	{produto.Preco}
)

SET @UserId = SCOPE_IDENTITY()

INSERT INTO toolbox.categorias_de_produtos (id_produto, id_categoria)
VALUES (@UserId, {produto.idCategoria})


ALTER TABLE toolbox.categoria
RENAME COLUMN 'nome' TO 'nome_categoria';

EXEC sp_rename 'toolbox.categoria.nome', 'nome_categoria', 'COLUMN';toolbox.categoria



INSERT INTO toolbox.emprestimo VALUES (
 	{IdLocador},
 	{IdLocatario},
 	{IdProdudot},
 	

);

INSERT INTO toolbox.endereco (id_usuario, logradouro, numero, bairro, cidade, estado, cep)
VALUES ((SELECT id FROM toolbox.usuario WHERE nome = 'Antônio Fagundes'), 'Rua Cládio Manuel', 1162, 'Savassi', 'Belo Horizonte', 'Minas Gerais', 30323456);


SELECT
    u.id,
	 nome,
    cpf,
    email,
    senha, 
    logradouro, 
    e.numero AS numero_endereco, 
    bairro, toolbox.usuario
    cidade, 
    estado, 
    cep, 
    t.numero AS numero_telefone, 
    codigo_area AS ddd
FROM toolbox.usuario AS u
LEFT JOIN toolbox.endereco AS e ON u.id = e.id_usuario
LEFT JOIN toolbox.telefone AS t ON u.id = t.id_usuario WHERE u.id = 1;

DELETE FROM toolbox.categorias_de_produtos WHERE id_produto = 48;
DELETE FROM toolbox.imagem_produto WHERE id_produto = 48;
DELETE FROM toolbox.produto WHERE id = 48;

INSERT INTO toolbox.emprestimo (id_locador, id_locatario, id_produto, data_inicio, data_fim, status, avaliacao, comentario)
VALUES (1, 2, 51, '2023-04-06', '2023-04-13', 'concluido', 5, 'Adorei');

SELECT
	e.id AS idEmprestimo,
	e.id_locador AS idLocador,
	e.id_locatario AS idLocatario,
	e.id_produto AS idProduto,
	locador.nome AS nomeLocador,
	prod.nome AS nomeProduto,
	e.data_inicio AS dataInicio,
	e.data_fim AS dataFim,
	e.status,
	e.avaliacao,
	e.comentario
FROM toolbox.emprestimo AS e
JOIN toolbox.usuario AS locador ON e.id_locador = locador.id
JOIN toolbox.usuario AS locatario ON e.id_locatario = locatario.id
JOIN toolbox.produto AS prod ON e.id_produto = prod.id;

INSERT INTO toolbox.emprestimo (id_locador, id_locatario, id_produto, data_inicio, data_fim, status, avaliacao, comentario)
VALUES (1, 2, 46, '2023-06-01', '2023-06-07', 'concluido', NULL, NULL);


UPDATE toolbox.emprestimo SET avaliacao=1 WHERE id=8;

SELECT nome AS nomeUsuario FROM toolbox.usuario;


SELECT
	u.id AS id_usuario,
	u.nome AS usuario,
	e.logradouro,
	e.numero,
	e.complemento,
	e.bairro,
	e.cidade,
	e.estado,
	e.cep
FROM toolbox.usuario AS u
FULL OUTER JOIN toolbox.endereco AS e ON u.id = e.id_usuario;


INSERT INTO toolbox.endereco (id_usuario, logradouro, numero, bairro, cidade, estado, cep)
VALUES (9, 'R. João Pio Duarte Silva', 1070, 'Córrego Grande', 'Florianópolis', 'SC', 88037001);


UPDATE toolbox.endereco
SET estado = 'PR'
WHERE estado = 'Paraná';



SELECT
	e.id AS id_emprestimo,
	p.nome,
	e.data_inicio,
	e.data_fim
FROM toolbox.emprestimo AS e
JOIN toolbox.produto AS p
ON p.id = e.id_produto;

UPDATE toolbox.emprestimo
SET
	data_fim = '28/06/2023 15:52:01'
WHERE id = 24;

ALTER TABLE toolbox.emprestimo ADD valor_total DECIMAL;

SELECT
	en.cidade,
	COUNT(em.id) AS numeroEmprestimos
FROM toolbox.endereco AS en
JOIN toolbox.usuario AS u ON u.id = en.id_usuario
JOIN toolbox.emprestimo AS em ON u.id = em.id_locatario
GROUP BY en.cidade;

SELECT u.nome
FROM toolbox.usuario AS u
JOIN toolbox.endereco AS e
ON u.id = e.id_usuario
WHERE e.cidade = 'Santos';

SELECT
	COUNT(e.id)
FROM toolbox.usuario AS u
JOIN toolbox.emprestimo AS e ON e.id_locatario = u.id
WHERE u.nome = 'Fernanda Torres';

-- --------------------------- INDICADORES DE QUALIDADE

-- Tempo medio de locação do mês corrente (Verificar tempo médio de locação de todos os produtos a cada mês)
SELECT
	data_inicio AS dataInicio,
	data_fim AS dataFim
FROM toolbox.emprestimo;

-- Valor médio de rentabilidade mensal de cada item (Verificar tempo médio de locação e o valor total obtido com cada item mensalmente)
SELECT
	p.nome AS nomeProduto,
	TO_DATE((SELECT data_inicio FROM toolbox.emprestimo), 'YYYY/MM/DD') AS dataInicio,
	data_fim AS dataFim,
	valor_total AS valorTotaltoolbox.reclamacaotoolbox.reclamacao
FROM toolbox.emprestimo AS e
JOIN toolbox.produto AS p ON p.id = e.id_produto
WHERE p.id = 45;


DELETE FROM toolbox.emprestimo WHERE id BETWEEN 39 AND 44;


-- Percentual de aumento de produtos anunciados por período (Entender o crescimento da plataforma medindo a quantidade de produtos anunciados em um determinado periodo)

-- Regiões/municipios com maior crescimento de clientes (Identificar regiões que não utilizam ou utilizam pouco a plataforma - Mede quantidade de clientes por localidade)

-- Quantidade de itens por produto/categoria

-- Clientes que mais negociam na plataforma

toolbox.emprestimotoolbox.reclamacao

