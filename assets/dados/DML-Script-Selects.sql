SELECT * FROM toolbox.usuario;

SELECT * FROM toolbox.categoria;

SELECT * FROM toolbox.produto;

-- Exibir nomes dos produtos e suas categorias
SELECT 
    p.nome AS nome_produto, c.nome AS nome_categoria
FROM
    toolbox.categorias_produtos AS cp
        JOIN
    toolbox.categoria AS c ON cp.id_categoria = c.id_categoria
        JOIN
    toolbox.produto AS p ON cp.id_produto = p.id_produto;