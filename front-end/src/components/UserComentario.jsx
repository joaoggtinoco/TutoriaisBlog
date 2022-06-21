import React from 'react';
import UserIcon from './iconeUser/UserIcon';
import Loading from './loading/Loading'
import './userComentario.css'

function UserComentario (){
  const [comment, setComment] = React.useState("");
  const [submitComment, setSubmitComment] = React.useState("");
  
  const [isSendingPost, setIsSendingPost] = React.useState(false);

  function handleSubmitPost(event){
    event.preventDefault();

    setIsSendingPost(true);
    setSubmitComment(comment);

    // Fazer req para api enviando o dado para o banco

    setIsSendingPost(false)
  }
  return (
    <div 
    className='container-main'
    >
      <div 
      className='container'
      >
        <UserIcon/>
        <h2 
        className='name-user'
        >
          Nome do usuario
        </h2>
      </div>
      <form 
        onSubmit={handleSubmitPost}
      >
        <textarea 
        className='text-field' 
        id="" 
        cols="50" 
        rows="10"
        onChange={(event) => setComment(event.target.value)}
        ></textarea>
        
        <footer>
          <button
            type='submit'
            disabled = {comment.length === 0 || isSendingPost}
          >
            {isSendingPost ? <Loading/> : 'Enviar Postagem'}
          </button>
        </footer>

      </form>
      <div>
        <p>
          {comment.length === 0 ? '' : submitComment}
        </p>
      </div>
    </div>
  );
}

export default UserComentario;
