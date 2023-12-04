var produto;


async function request(method, url) {
  const response = await fetch(url, {
    method: method,
  });
  const responseData = await response.json();

  if (!response.ok) {
    throw new Error(responseData.message || 'Failed to fetch.');
  }
  return responseData;
}

async function getUserById() {
  const data = await request('GET', "https://localhost:7146/api/cadastroitens");
  produto = data;
  renderProduto(data)
}



let cardsProdutos = document.getElementById("cards-produtos");

function renderProduto(proudutos) {
  let cards = "";
  var img = [];
  let imagens;
  proudutos.forEach(element => {
    if (element.path) {
      imagens = element.path.split('$$');
    }
    cards += `
    <div class="col">
  <a href="./anuncio.html" onclick="salvaId('${element.id}')" style="text-decoration: none;">
    <div class="card shadow-sm">
    <img class="imageBox" src="${imagens[0]}" alt="">
      <div class="card-body card-description">
        <h5>${element.nome}</h5>
        <h6><strong>R$${element.preco}</strong></h6>
        
      </div>
    </div>
  </a>
</div>

    `
  });


  cardsProdutos.innerHTML = cards;
}
function CarregaProdutos(categoria) {
  let produtosCategoria = []
  produto.forEach(element => {
    if (element.nome_categoria == categoria) {
      produtosCategoria.push(element);
    }
  });
  if (produtosCategoria == null)
    renderProduto(produto)
  else
    renderProduto(produtosCategoria)
}

function pesquisaItens(event) {
  event.preventDefault();
  let termoPesquisa = document.getElementById("pesquisa").value;
  let produtosCategoria = [];
  produto.forEach(element => {
    if (element.nome.toLowerCase().includes(termoPesquisa.toLowerCase())) {
      produtosCategoria.push(element);
    }
  });
  renderProduto(produtosCategoria);
}

function salvaId(id) {
  localStorage.setItem("id", id);
}

window.onload = function () {
  var teste = localStorage.getItem("logado")
  if (!teste || teste == false) {
    window.location.href = "login.html";
  }

}


getUserById()