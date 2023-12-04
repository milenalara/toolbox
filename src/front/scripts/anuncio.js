const container = document.getElementById("container-produto");
const imagem = document.getElementById("imagens-produto");
class comentario{
  nome;
  descricao;
  avaliacao;
};
var produto;
var id;
var i=0;

function getid(){
 id = localStorage.getItem("id")
}

function inserirImg(){
  let imagens = [];
  if(produto){
    imagens.push(produto[0].path.split('$$'));
    if(imagens.length >0)
      return imagens;
    else
      return imagens = null;
  }
}

function mudaImgDireita(){
  let img =inserirImg()
  if(img == null){
    carrregaImg(produto[0].path)
  }else{
    if(i+1 < img.length)
    carrregaImg(img[i+1])
  }
}

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

async function geProdutos() {
 getid();
 const data = await request('GET', "https://localhost:7146/api/cadastroitens/" + id);
 produto = data;
  renderProduto(produto)
}

 function carrregaImg(imagens){
  let img = `           
  <img src="${imagens}" class="d-block h-100" alt="...">
  `
  imagem.innerHTML = img
}

function renderProduto(produtoCarregar) {
  let produtoInfo = `
  <div class="container-fluid py-2">
    <h2 class="fw-bold mb-3">${produtoCarregar[0].nome}</h2>

    <h4 class="fw-bold m">Descrição:</h4>
    <p class="col-md-12 mt-3">${produtoCarregar[0].descricao}</p>

    <h4 class="fw-bold m">Detalhes:</h4>
    <h5 class="fw-bold m">Categoria: ${produtoCarregar[0].nome_categoria}</h5>
    <h5 class="fw-bold m">Marca: ${produtoCarregar[0].marca}</h5>
    <h5 class="fw-bold m">Condições: ${produtoCarregar[0].condicao}</h5>

    <div class="w-100 botao-alugue">
      <p class="fs-1 m-auto mb-2">R$ ${produtoCarregar[0].preco}</p>
      <button class="btn btn-danger btn-lg w-75 m-auto" onclick="exibirModal()">Alugue este produto</button>
      </div>
    </div>
    <div id="modal" class="modalResponse" style="display: none;">
  <div class=" d-flex justify-content-center align-items-center">

    <div class='checkout'>

      <div class='order'>
        <h2>Confirmar Produto</h2>
        <h4>${produtoCarregar[0].nome}</h4>
        <h5>Marca: ${produtoCarregar[0].marca}</h5>
        <h5>Condições: ${produtoCarregar[0].condicao}</h5>
        <br>
        <input style=" align-items: center;" class="form-control" type="number" id="valueSemana" placeholder="Digite o numero de semanas" min="1" max="10">
        <h5 class='total'>Total</h5>
        <h1>R$ ${produtoCarregar[0].preco}</h1>  

      <div style="margin-top: 20%;" class="d-flex justify-content-between">        
        <a class="w-45"><button class="m-auto" onclick="fecharModal()">Fechar</button></a>        
        <button class="w-45" onclick="AluguelProduto()">Confirmar</button>
      </div>
      </div>
      
    </div>
    
  </div>
</div>
  
   
  `
  container.innerHTML = produtoInfo;
  let produtoFinal = produto[0].path.split("$$");
  carrregaImg(produtoFinal[0]);
  getComentario();
}
function exibirModal() {
  document.getElementById("modal").style.display = "flex";
}

geProdutos();

async function getComentario() {
  let id = localStorage.getItem("id");
  var url = "https://localhost:7146/api/EmprestimoItens/comentario/" + id;
  const data = await request('GET', url);
  loadComments(data); // Passa os dados para a função loadComments()
}

function loadComments(data) {
  var commentSection = document.getElementById("comment-section");
  var comentario = document.getElementById("inativar");
  commentSection.innerHTML = "";
  
    data.forEach(function(comment){
      if(comment.comentario || comment.avaliacao > 0){
        comentario.style.display="block";
        if(!comment.comentario)
        comment.comentario = "...";
      var div = document.createElement("div");
      div.className = "comment-card";
      div.innerHTML = `
        <h3>${comment.nome}</h3>
        <p>${comment.comentario}</p>
        <div class="rating">${"★".repeat(comment.avaliacao)}</div>
      `;
     commentSection.appendChild(div);
      }
  });
}
class Aluguel {
  idLocador 
  idLocatario
  idProduto
  dataFim
  
}
var aluguel = new Aluguel();

function AluguelProduto() {
  let temp = document.getElementById("valueSemana").value;
  if(temp<=0){
    temp=1;
  }
  aluguel.idLocador = produto[0].id_usuario;
  aluguel.idLocatario = localStorage.getItem("idUsuario")
  aluguel.idProduto = localStorage.getItem("id")
  aluguel.dataFim = somarSemanas(temp)
  cadastraAlocacao(aluguel);
};

async function alocar(method, url, data) {
  const response = await fetch(url, {
    method: method,
    headers: {
      'Content-Type': 'application/json'
    },
    body: data ? JSON.stringify(data) : undefined
   });
  const responseData = await response.json();

if (!response.ok) {
  exibirMensagem("Erro ao alocar o produto")
}else{
  fecharModal();
  exibirMensagem("Produto alocado com sucesso");
}

}

async function cadastraAlocacao(item) {
  const data = await alocar('POST', 'https://localhost:7146/api/EmprestimoItens', item);
}

function somarSemanas(numeroSemanas) {
  // Obtém a data e hora atual
  var dataAtual = new Date();

  // Adiciona o número de semanas à data atual
  var dataSomada = new Date(dataAtual.getTime() + (numeroSemanas * 7 * 24 * 60 * 60 * 1000));

  // Formata a data no formato desejado (dd/mm/yyyy hh:mm)
  var dia = dataSomada.getDate().toString().padStart(2, '0');
  var mes = (dataSomada.getMonth() + 1).toString().padStart(2, '0');
  var ano = dataSomada.getFullYear();
  var hora = dataSomada.getHours().toString().padStart(2, '0');
  var minutos = dataSomada.getMinutes().toString().padStart(2, '0');

  // Retorna a data e hora formatada
  return dia + '/' + mes + '/' + ano + ' ' + hora + ':' + minutos;
}

function exibirMensagem(modal) {
document.getElementById("modalTeste").style.display = "flex";
document.getElementById("mensagem").innerHTML = modal;
}

function fecharModal(modal) {
document.getElementById("modal").style.display = "none";
}


