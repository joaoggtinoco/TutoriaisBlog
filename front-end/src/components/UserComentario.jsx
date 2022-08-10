import React from 'react'
import UserIcon from './iconeUser/UserIcon'
import Loading from './loading/Loading'
import './userComentario.css'
import axios from 'axios'

function UserComentario() {
  const [description, setDescription] = React.useState('')
  const [loading, setLoading] = React.useState(false)

  // So pra ver o texto quando clicar no botao enviar
  const [submitComment, setSubmitComment] = React.useState('')

  function handleSubmitPost(event) {
    event.preventDefault()
    setLoading(true)
    setSubmitComment(description)
    axios
      .post('https://localhost:7276/api/Postagem', {
        conteudo: description,
        usuarioId: 8
      })
      .then(() => {
        alert('Post enviado')
        setLoading(false)
      })
      .catch(() => {
        alert('Deu erro')
        setLoading(false)
      })

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
          <button type="submit" disabled={description.length === 0 || loading}>
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
