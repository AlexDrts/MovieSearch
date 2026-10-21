import { useEffect, useState } from 'react'
import { Link } from 'react-router-dom'
import { getMovies, posterUrl } from '../api.js'

export default function MovieList() {
  const [movies, setMovies] = useState([])
  const [loading, setLoading] = useState(true)
  const [error, setError] = useState('')

  useEffect(() => {
    getMovies()
      .then(setMovies)
      .catch(() => setError('Не вдалося завантажити фільми. Перевірте, чи запущений сервер.'))
      .finally(() => setLoading(false))
  }, [])

  if (loading) return <p className="message">Завантаження...</p>
  if (error) return <p className="message error">{error}</p>

  return (
    <>
      <h2>Топ-10 найкращих фільмів</h2>

      {movies.length === 0 && <p className="message">Список фільмів порожній.</p>}

      <div className="movies-grid">
        {movies.map((movie) => (
          <div key={movie.id} className="movie-card">
            <img src={posterUrl(movie.posterPath)} alt={movie.title} className="movie-poster" />
            <div className="movie-body">
              <h4>{movie.title}</h4>
              <p className="movie-meta">{movie.releaseYear} · {movie.genre}</p>
              <p className="movie-director"><strong>Режисер:</strong> {movie.director}</p>
              <p className="movie-description">{movie.description}</p>
              <Link to={`/movies/${movie.id}`} className="btn btn-primary">Детальніше</Link>
            </div>
          </div>
        ))}
      </div>
    </>
  )
}
