class Produto {
  constructor() {
    this.Descricao = null;
    this.imagem = null;
    this.idCategoria = null;
    this.idProduto = null;
  }
}

function Reclamacao(Descricao) {
  let produto = new Produto();
  produto.Descricao = Descricao;
  produto.idCategoria = null;
  produto.idProduto = null;
  return produto;
}

function reclamacaoProduto() {
  let Descricao = document.getElementById('descricao').value;
  let imagem = document.getElementById('file-input').files[0];

  let reader = new FileReader();
  reader.onload = function(event) {
    let reclamar = Reclamacao(Descricao);
    reclamar.imagem = event.target.result;
    reclamacaoproduto(reclamar);
    console.log(reclamar);
    };
      reader.readAsDataURL(imagem);
    
         
}

async function request(method, url, data) {
  const response = await fetch(url, {
    method: method,
    headers: {
      'Content-Type': 'application/json'
    },
    body: data ? JSON.stringify(data) : undefined
  });
  const responseData = await response.json();

  if (!response.ok) {
    throw new Error(responseData || 'Failed to fetch.');
  }
  return responseData; 
  
}

async function getUsers() {
  const data = await request('GET', 'https://example.com/api/users');
  console.log(data);
}

async function reclamacaoproduto(user) {
  const data = await request('POST', 'https://localhost:44395/api/cadastroitens', JSON.stringify(user));
  if (responseData) {
    exibirMensagem("Sua reclamação foi enviada!");
  } else {
    exibirMensagem("Erro na reclamação");
  }
}

async function updateUser(id, user) {
  const data = await request('PUT', `https://example.com/api/users/${id}`, user);
  console.log(data);
}

async function deleteUser(id) {
  const data = await request('DELETE', `https://example.com/api/users/${id}`);
  console.log(data);
}

function exibirMensagem(modal) {
  document.getElementById("modal").style.display = "flex";
  document.getElementById("mensagem").innerHTML = modal;
}

function fecharModal() {
  document.getElementById("modal").style.display = "none";
}