class Produto {
    nome 
    Condicao
    marca
    Descricao
    Preco
    path = []
    id_categoria
    nome_categoria = null
    image = null
    id_usuario
}
var produto = new Produto();

function anunciarProduto() {
    produto.nome = document.getElementById('item').value;
    produto.descricao = document.getElementById('descricao').value;
    produto.id_categoria = document.getElementById('id_categoria').value;
    produto.Condicao = document.getElementById('Condicao').value;
    produto.Preco = document.getElementById('valor').value;
    produto.marca = document.getElementById('marca').value;
    produto.id_usuario= localStorage.getItem("idUsuario")
    produto.categoria; 

    cadastraProduto(produto);
  };
  
function carregarImagens(inputImagem) {
  var cardContainer = document.getElementById('cardContainer');
      cardContainer.classList.add('cardContainer')
      var card = document.createElement('div');
      card.classList.add('card');
      var img = document.createElement('img');
      img.src = inputImagem;
      card.appendChild(img);
      cardContainer.appendChild(card);
  }

  window.addEventListener('DOMContentLoaded', function() {
    var inputImagem = document.getElementById('imagem');
    inputImagem.addEventListener('change', function(event) {
      var file = event.target.files[0];
      var reader = new FileReader();
      reader.onload = function(event) {
        var imagemBase64 = event.target.result;
        produto.path = imagemBase64 + "$$" 
        console.log(produto.path)
        carregarImagens(imagemBase64);
      };
  
      reader.readAsDataURL(file);
    });
  });

  function base64ToBytes(base64) {
    const binaryString = window.atob(btoa(base64));
    const bytes = new Uint8Array(binaryString.length);
    for (let i = 0; i < binaryString.length; i++) {
      bytes[i] = binaryString.charCodeAt(i);
    }
    return bytes;
  }

async function request(method, url, data) {
    const response = await fetch(url, {
      method: method,
      headers: {
        'Content-Type': 'application/json'
      },
      body: data ? JSON.stringify(data) : undefined
     });
    const responseData = await response.json();
  
  if (!response.ok) {
    exibirMensagem("Erro ao cadastrar o produto")
  }
  if(responseData == true){
    exibirMensagem("Produto cadastrado com sucesso")
  }else
  exibirMensagem("Erro ao cadastrar o produto")
  
}
  
  async function cadastraProduto(item) {
    const data = await request('POST', 'https://localhost:7146/api/cadastroitens', item);
    console.log(data);
  }

function exibirMensagem(modal) {
  document.getElementById("modal").style.display = "flex";
  document.getElementById("mensagem").innerHTML = modal;
}

function fecharModal() {
  document.getElementById("modal").style.display = "none";
}
