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
    throw new Error(responseData.message || 'Failed to fetch.');
  }

  console.log(responseData);
}

async function getUsers() {
  const data = await request('GET', 'https://localhost:7146/api/CadastroUsuario');
  console.log(data);
}

async function postNewUser(user) {
  const data = await request('POST', 'https://localhost:7146/api/CadastroUsuario', user);
  console.log(data);
}


async function createNewUser() {
  user = new User()
  user.Id = 0
  user.Nome = document.getElementById('name').value
  user.Cpf = document.getElementById('cpf').value
  user.Email = document.getElementById('email').value
  user.senha = document.getElementById('password').value
  user.checkPassword = document.getElementById('check-password').value
  user.logradouro = document.getElementById('street').value
  user.numero = document.getElementById('number').value
  user.bairro = document.getElementById('neighborhood').value
  user.cidade = document.getElementById('city').value
  user.estado = document.getElementById('state').value
  user.cep = document.getElementById('zip-code').value
  user.numero_telefone = document.getElementById('phone').value.slice(5, 15)
  user.DDD = document.getElementById('phone').value.slice(0, 4)

  console.log(user);
  return user
}

async function registerNewUser() {
  const newUser = await createNewUser()
  postNewUser(newUser)
}

const registerButton = document.getElementById('register')

registerButton.addEventListener('click', (event) => {
  event.preventDefault()
  registerNewUser()
  alert("Usuário criado com sucesso")
})

class User {
  Id
  Nome
  Cpf
  Email
  senha
  checkPassword
  logradouro
  numero
  bairro
  cidade
  estado
  cep
  numero_telefone
  DDD
}