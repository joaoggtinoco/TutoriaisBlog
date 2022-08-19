import { BrowserRouter } from 'react-router-dom'
import { Router } from './Router'
function App() {
  return (
    <div className="h-[100vh] flex flex-col justify-between">
      <BrowserRouter>
        <Router/>
      </BrowserRouter>
    </div>
  )
}

export default App
