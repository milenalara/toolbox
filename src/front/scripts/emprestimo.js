
const formulario = document.getElementById("emprestimoForm")
const nomeEmprestimo = document.getElementById('nomeEmprestimo')
const dataInicio = document.getElementById('dataInicio')
const dataFim = document.getElementById('dataFim')
const statusEmp = document.getElementById('status')
const agendarDevolucaoButton = document.getElementById('agendarDevolucao')
const enviarReclamacaoButton = document.getElementById('enviarReclamacao')
const enviarAvaliacaoButton = document.getElementById('enviarAvaliacao')
const idEmprestimo = JSON.parse(localStorage.getItem('idEmprestimo'));
const avaliacaoRadios = document.getElementsByName('avaliacao')
const agendarSection = document.getElementById('agendar')
const inputDataFinal = document.getElementById('inputDataHora')
const inputReclamacao = document.getElementById('inputReclamacao')
const inputCondicao = document.getElementById('inputCondicao')

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

async function getEmprestimo() {
  const data = await request('GET', `https://localhost:7146/api/EmprestimoItens/${idEmprestimo}`);
  return data;
}

async function updateEmprestimo(id, dataFinal) {
  return await request('PUT', `https://localhost:7146/api/EmprestimoItens/datadevolucao/${id}`, dataFinal);
}

async function updateAvaliacao(id, aval) {
  return await request('PUT', `https://localhost:7146/api/EmprestimoItens/avaliacao/${id}`, aval);
}

async function renderEmprestimoData() {
  const data = await getEmprestimo()
  const emprestimoData = data[0]
  nomeEmprestimo.innerHTML = `${emprestimoData.nomeProduto}`
  dataInicio.innerHTML = `${emprestimoData.dataInicio}`
  dataFim.innerHTML = `${emprestimoData.dataFim}`
  statusEmp.innerHTML = `${emprestimoData.status}`
}

async function renderAgendamento() {
  const data = await getEmprestimo()
  const emprestimoData = data[0]
  if (emprestimoData.status == "concluido") {
    agendarSection.style.display = "none";
  }
}

async function enviarReclamacao() {
  const reclamacao = {
    "idEmprestimo": JSON.parse(localStorage.getItem('idEmprestimo')),
    "condicao": inputCondicao.value,
    "descricao": inputReclamacao.value
  }

  console.log(reclamacao.idEmprestimo);
  console.log(reclamacao.condicao);
  console.log(reclamacao.descricao);

  alert("Reclamação enviada com sucesso")
  return await request('POST', `https://localhost:7146/api/Reclamacao`, reclamacao);
}

async function agendarDevolucao() {
  const dataDevolucao = inputDataFinal.value

  const dateOptions = {
    year: 'numeric',
    month: 'numeric',
    day: 'numeric',
  }

  const timeOptions = {
    hour: 'numeric',
    minute: 'numeric',
  }

  const dataFinal = new Date(dataDevolucao).toLocaleDateString('pt-br', dateOptions)
  const horaFinal = new Date(dataDevolucao).toLocaleTimeString('pt-br', timeOptions)
  const enviarData = dataFinal + " " + horaFinal

  updateEmprestimo(idEmprestimo, enviarData)
  alert("Devolução agendada com sucesso")
}

async function enviarAvaliacao() {
  const avaliacao = document.querySelector('input[name="avaliacao"]:checked').value
  console.log('avaliacao', avaliacao)
  id = JSON.parse(localStorage.getItem('idEmprestimo'))
  updateAvaliacao(id, avaliacao)
  alert("Avaliação enviada com sucesso")
}

agendarDevolucaoButton.addEventListener('click', async (event) => {
  event.preventDefault()
  agendarDevolucao()
})

enviarReclamacaoButton.addEventListener('click', async (event) => {
  event.preventDefault()
  enviarReclamacao()
})

enviarAvaliacaoButton.addEventListener('click', async (event) => {
  event.preventDefault()
  enviarAvaliacao()
})

// async function enviarAvaliacao(emprestimo) {
//   const avaliacaoForm = document.getElementById('avaliacaoForm')
//   const comentario = avaliacaoForm.elements['inputComentario'].value
//   const avaliacao = document.querySelector('input[name="avaliacao"]:checked').value

//   try {
//     await updateEmprestimo(emprestimo.idProduto, { ...emprestimo, avaliacao: avaliacao, comentario: comentario })
//   } catch (error) {
//     console.log(error);
//   }
// }

// enviarAvaliacaoButton.addEventListener('click', async (event) => {
//   event.preventDefault()

//   await enviarAvaliacao(emprestimoData)
// })

renderEmprestimoData();
renderAgendamento();