const itens = document.getElementById("itens-emprestimo");
const btnSalvar = document.getElementById("btn-salvar");

async function request(method, url, data) {
  const response = await fetch(url, {
    method: method,
    headers: {
      'Content-Type': 'application/json',
      'Accept': 'application/json'
    },
    body: data ? JSON.stringify(data) : undefined
  });
  const responseData = await response.json();

  if (!response.ok) {
    throw new Error(responseData.message || 'Failed to fetch.');
  }
  return responseData
}

async function getEmprestimos() {
  var id = localStorage.getItem("idUsuario")
  const data = await request('GET', `https://localhost:7146/api/EmprestimoItens/alocados/`+id);
  return data;
}

async function renderEmprestimos() {
  const emprestimos = await getEmprestimos()
  console.log(emprestimos)
  let listagemEmprestimos = ''
  for (let index = 0; index < emprestimos.length; index++) {
    const emprestimo = emprestimos[index];
    const buttonId = `disable-${emprestimo.idEmprestimo}`; // ID único para cada botão
  
    listagemEmprestimos = `
      <tr>
        <th scope="row" colspan="8">${emprestimo.nomeProduto}</th>
        <td>${emprestimo.nomeLocador}</td>
        <td>${emprestimo.dataInicio}</td>
        <td>${emprestimo.dataFim}</td>
        <td id="${emprestimo.idEmprestimo}">${emprestimo.status}</td>
        <td><button type="button" id="${buttonId}" class="custom-button" style="text-align: center; border-radius: 20px; background-color: blue;" onclick="alteraStatus('agendado', this.id)">Aprovar</button></td>
        <td><button type="button" id="${buttonId}-reprovar" class="custom-button" style="text-align: center; border-radius: 20px; background-color: red;" onclick="alteraStatus('rejeitado', this.id)">Reprovar</button></td>
      </tr>
    `;
  
    itens.innerHTML += listagemEmprestimos;
  
    if (emprestimo.status != "pendente") {
      let disableButton = document.getElementById(buttonId);
      let disableReprovarButton = document.getElementById(`${buttonId}-reprovar`);
      disableButton.disabled = true;
      disableReprovarButton.disabled = true;
      disableButton.style.backgroundColor = "gray";
      disableReprovarButton.style.backgroundColor = "gray";
    }
  } 
}
 var urlStatus;
 var status = "";



function alteraStatus(statusButton, id){
  id = id.substring(8,10)
  console.log(id)
  status = statusButton;
  urlStatus= "https://localhost:7146/api/EmprestimoItens/status/"+id;
  if(statusButton=="rejeitado")
    exibirMensagem("A alocação será regeitada!")
  else
  exibirMensagem("A alocação será aprovada!")
}

function exibirMensagem(modal) {
  document.getElementById("modal").style.display = "flex";
  document.getElementById("mensagem").innerHTML = modal;
}
function setStatus() {
  request('PUT', urlStatus, status)
  document.getElementById("modal").style.display = "none";
}

function fecharModal() {
  document.getElementById("modal").style.display = "none";
}

async function updateAvaliacao(id) {
  const data = await request('PUT', `https://localhost:7146/api/EmprestimoItens/${id}`);
  return data;
}



renderEmprestimos()