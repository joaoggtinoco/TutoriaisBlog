import UserComentario from '../components/UserComentario/UserComentario'
import Header from '../components/Header'
import Footer from '../components/Footer'

export default function Blog() {
  return (
    <div className='h-[100vh] flex flex-col justify-between'>
      <Header type='defaultUser'/>
      <UserComentario />
      <Footer />
    </div>
  )
}
