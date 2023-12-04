
const formulario = document.getElementById("formulario-usuario")
let userId = JSON.parse(localStorage.getItem('idUsuario'));
const inputId = Number(JSON.parse(localStorage.getItem('idUsuario')))
const inputNome = document.getElementById('inputNome')
const inputCpf = document.getElementById('inputCPF')
const inputEmail = document.getElementById('inputEmail')
const inputSenha = document.getElementById('inputSenha')
const inputLogradouro = document.getElementById('inputLogradouro')
const inputNumeroEndereco = document.getElementById('inputNumeroEndereco')
const inputBairro = document.getElementById('inputBairro')
const inputCidade = document.getElementById('inputCidade')
const inputEstado = document.getElementById('inputEstado')
const inputCep = document.getElementById('inputCep')
const inputNumeroTelefone = document.getElementById('inputTelefone')
const inputDdd = document.getElementById('inputDdd')
const btnSalvar = document.getElementById('btn-salvar')

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
  const data = await request('GET', `https://localhost:7146/api/CadastroUsuario/${userId}`);
  return data;
}

async function renderUserData() {
  const usuario = await getEmprestimos();

  inputNome.value = usuario[0].nome
  inputCpf.value = usuario[0].cpf
  inputEmail.value = usuario[0].email
  inputLogradouro.value = usuario[0].logradouro
  inputNumeroEndereco.value = usuario[0].numero_endereco
  inputBairro.value = usuario[0].bairro
  inputCidade.value = usuario[0].cidade
  inputEstado.value = usuario[0].estado
  inputCep.value = usuario[0].cep
  inputNumeroTelefone.value = usuario[0].numero_telefone
  inputDdd.value = usuario[0].ddd
  inputSenha.value = usuario[0].senha
}

async function createNewUser() {
  user = new User()
  user.Id = Number(userId)
  user.Nome = document.getElementById('inputNome').value
  user.Cpf = document.getElementById('inputCPF').value
  user.Email = document.getElementById('inputEmail').value
  user.senha = document.getElementById('inputSenha').value
  user.logradouro = document.getElementById('inputLogradouro').value
  user.numero_endereco = document.getElementById('inputNumeroEndereco').value
  user.bairro = document.getElementById('inputBairro').value
  user.cidade = document.getElementById('inputCidade').value
  user.estado = document.getElementById('inputEstado').value
  user.cep = document.getElementById('inputCep').value
  user.numero_telefone = document.getElementById('inputTelefone').value
  user.DDD = document.getElementById('inputDdd').value
  return user
}

async function updateUser(user) {
  const data = await request('PUT', `https://localhost:7146/api/CadastroUsuario/${userId}`, user);
  console.log(data);
}

async function registerNewUser() {
  const newUser = await createNewUser()
  console.log(newUser)
  updateUser(newUser)
  alert("Dados alterados com sucesso")
}

btnSalvar.addEventListener('click', (event) => {
  event.preventDefault()
  registerNewUser()
})

class User {
  Id
  Nome
  Cpf
  Email
  senha
  logradouro
  numero_endereco
  bairro
  cidade
  estado
  cep
  numero_telefone
  DDD
}

renderUserData();