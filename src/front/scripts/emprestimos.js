const itens = document.getElementById("itens-emprestimo");
const btnSalvar = document.getElementById("btn-salvar");
let userId = JSON.parse(localStorage.getItem('idUsuario'));

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
  const data = await request('GET', `https://localhost:7146/api/EmprestimoItens/dosponiveis/${userId}`);
  return data;
}

async function renderEmprestimos() {
  const emprestimos = await getEmprestimos()
  console.log(emprestimos)
  let listagemEmprestimos = ''

  for (let index = 0; index < emprestimos.length; index++) {
    const emprestimo = emprestimos[index];
    console.log("emprestimo", emprestimo.idEmprestimo)
    listagemEmprestimos += `
    <tr>
      <th scope="row" colspan="8">${emprestimo.nomeProduto}</th>
      <td>${emprestimo.nomeLocador}</td>
      <td>${emprestimo.dataInicio}</td>
      <td>${emprestimo.dataFim}</td>
      <td>${emprestimo.status}</td>
      <td>
          <a href="./emprestimo.html" onclick="salvarId(${emprestimo.idEmprestimo})" id="${emprestimo.idEmprestimo}">saiba +</button>
      </td>
    </tr>
    `

  }

  itens.innerHTML = listagemEmprestimos

}

async function updateAvaliacao(id) {
  const data = await request('PUT', `https://localhost:7146/api/EmprestimoItens/${id}`);
  return data;
}

function salvarId(idEmprestimo) {
  localStorage.setItem('idEmprestimo', idEmprestimo)
}

renderEmprestimos()
