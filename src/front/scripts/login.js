document.getElementById("login_button").addEventListener("click", function(event) {
    event.preventDefault(); });

const mode = document.getElementById('mode_icon');

mode.addEventListener('click', () => {
    const form = document.getElementById('login_form');

    if(mode.classList.contains('fa-moon')) {
        mode.classList.remove('fa-moon');
        mode.classList.add('fa-sun');

        form.classList.add('dark');
        return ;
    }
    
    mode.classList.remove('fa-sun');
    mode.classList.add('fa-moon');

    form.classList.remove('dark');
});

function iniciaUsuario(){
    let email = document.getElementById('email').value
    let senha = document.getElementById('password').value
    var url = `https://localhost:7146/api/CadastroUsuario/${email}/${senha}`
    return url;
}
var id;
function validaLogin(){
    url = iniciaUsuario()
    getLogin(url);
}

async function request(method, url) {
    const response = await fetch(url, {
        method: method,
        headers: {
          'Content-Type': 'application/json',
          'Accept': 'application/json'
        },
      });
      const responseData = await response.json();
    
      if (!response.ok) {
        throw new Error(responseData.message || 'Failed to fetch.');
      }
      return responseData
  }

async function getLogin(url) {
   const data = await request('GET', url);
   
   if(data[0]>0){
    localStorage.setItem("logado", true);
    localStorage.setItem("idUsuario", data[0]);
    window.location.href = "index.html";
    }
}

function exibirMensagem(modal) {
    document.getElementById("modal").style.display = "flex";
    document.getElementById("mensagem").innerHTML = modal;
}
  
function fecharModal() {
    document.getElementById("modal").style.display = "none";
}
  