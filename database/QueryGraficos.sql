--GraficoVendasAnual
SELECT 
	DATENAME(MONTH, DATEADD(MONTH, MONTH(data_pedido), '2000-12-01')) AS 'Month Name',
	COUNT(*) 
FROM      
	pedido 
WHERE     
	YEAR(data_pedido) = '2022' 
GROUP BY 
	MONTH(data_pedido)



SELECT
	mp.nome,
	COUNT(*)
FROM
	pedido pe

	INNER JOIN carrinho ca on
		ca.codigo = pe.codigo_carrinho

	INNER JOIN produto_dados pd on
		pd.codigo = ca.codigo_produto_dados
	
	INNER JOIN produto p on
		p.codigo = pd.codigo_produto
	
	INNER JOIN marca_produto mp on
		mp.codigo = p.codigo_marca
GROUP BY 
	mp.codigo,
	mp.nome


SELECT
	pc.nome,
	COUNT(*)
FROM
	pedido pe

	INNER JOIN carrinho ca on
		ca.codigo = pe.codigo_carrinho

	INNER JOIN produto_dados pd on
		pd.codigo = ca.codigo_produto_dados
	
	INNER JOIN produto p on
		p.codigo = pd.codigo_produto
	
	INNER JOIN produto_categoria pc on
		pc.codigo = p.codigo_marca
GROUP BY 
	pc.codigo,
	pc.nome