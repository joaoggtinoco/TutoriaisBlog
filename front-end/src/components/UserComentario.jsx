import { gql, useMutation } from '@apollo/client'
import React from 'react'
import { useEffect } from 'react'
import UserIcon from './iconeUser/UserIcon'
import Loading from './loading/Loading'
import './userComentario.css'
import axios from "axios"

const CREATE_USER_POST = gql`
  mutation CreateUserPost($description: String!) {
    createUserPost(data: { description: $description }) {
      id
    }
  }
`

function UserComentario() {

  const [description, setDescription] = React.useState('')
  
  /*
  useEffect(() => {
    axios.post("https://localhost:7276/api/Postagem"), {
      conteudo: description,
      usuarioId: 8 
    }
      .then(() => {
        alert("Post enviado")
      })
      .catch(() =>{
        alert("Deu erro")
      })
  });
*/




  const [createPost, {loading}] = useMutation(CREATE_USER_POST);

  // So pra ver o texto quando clicar no botao enviar
  const [submitComment, setSubmitComment] = React.useState('')

  function handleSubmitPost(event) {
    event.preventDefault()
    setSubmitComment(description)
    axios.post("https://localhost:7276/api/Postagem", {
      conteudo: description,
      usuarioId: 8 
    })
      .then(() => {
        alert("Post enviado")
      })
      .catch(() =>{
        alert("Deu erro")
      })
  

    // Fazer req para api enviando o dado para o banco
    createPost({
      variables:{
        // Essa variavel de estado tem que ter o mesmo nome na req da mutation
        description
      }
    })

    console.log(`Toke: ${process.env.REACT_APP_API_ACCESS_TOKEN}`)
    console.log(`Base URL: ${process.env.REACT_APP_URI}`)
  }
  return (
    <div className="container-main">
      <div className="container">
        <UserIcon />
        <h2 className="name-user">Nome do usuario</h2>
      </div>
      <form onSubmit={handleSubmitPost}>
        <textarea
          className="text-field"
          id=""
          cols="50"
          rows="10"
          onChange={event => setDescription(event.target.value)}
        ></textarea>

        <footer>
          <button
            type="submit"
            disabled={description.length === 0 || loading}
          >
            {loading ? <Loading /> : 'Enviar Postagem'}
          </button>
        </footer>
      </form>
      <div>
        <p>{description.length === 0 ? '' : submitComment}</p>
      </div>
    </div>
  )
}

export default UserComentario
