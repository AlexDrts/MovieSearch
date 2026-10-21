import { Link, Route, Routes } from 'react-router-dom'
import MovieList from './pages/MovieList.jsx'
import MovieDetails from './pages/MovieDetails.jsx'
import MovieForm from './pages/MovieForm.jsx'
import NotFound from './pages/NotFound.jsx'

export default function App() {
  return (
    <>
      <header className="header">
        <div className="container header-inner">
          <Link to="/" className="logo">🎬 Кінопошук</Link>
          <Link to="/create" className="btn btn-success">+ Додати фільм</Link>
        </div>
      </header>

      <main className="container">
        <Routes>
          <Route path="/" element={<MovieList />} />
          <Route path="/movies/:id" element={<MovieDetails />} />
          <Route path="/create" element={<MovieForm />} />
          <Route path="/edit/:id" element={<MovieForm />} />
          <Route path="*" element={<NotFound />} />
        </Routes>
      </main>
    </>
  )
}
