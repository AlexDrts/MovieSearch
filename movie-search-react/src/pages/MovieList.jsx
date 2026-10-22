import { useEffect, useState } from 'react'
import { Link } from 'react-router-dom'
import { useTranslation } from 'react-i18next'
import { getMovies, posterUrl } from '../api.js'

export default function MovieList() {
  const { t } = useTranslation()
  const [movies, setMovies] = useState([])
  const [loading, setLoading] = useState(true)
  const [error, setError] = useState(false)

  useEffect(() => {
    getMovies()
      .then(setMovies)
      .catch(() => setError(true))
      .finally(() => setLoading(false))
  }, [])

  if (loading) return <p className="message">{t('common.loading')}</p>
  if (error) return <p className="message error">{t('list.loadError')}</p>

  return (
    <>
      <h2>{t('list.title')}</h2>

      {movies.length === 0 && <p className="message">{t('list.empty')}</p>}

      <div className="movies-grid">
        {movies.map((movie) => (
          <div key={movie.id} className="movie-card">
            <img src={posterUrl(movie.posterPath)} alt={movie.title} className="movie-poster" />
            <div className="movie-body">
              <h4>{movie.title}</h4>
              <p className="movie-meta">{movie.releaseYear} · {movie.genre}</p>
              <p className="movie-director"><strong>{t('list.director')}</strong> {movie.director}</p>
              <p className="movie-description">{movie.description}</p>
              <Link to={`/movies/${movie.id}`} className="btn btn-primary">{t('common.details')}</Link>
            </div>
          </div>
        ))}
      </div>
    </>
  )
}
