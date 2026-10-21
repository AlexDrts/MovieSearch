import { useEffect, useState } from 'react'
import { Link, useNavigate, useParams } from 'react-router-dom'
import { deleteMovie, getMovie, posterUrl } from '../api.js'

export default function MovieDetails() {
  const { id } = useParams()
  const navigate = useNavigate()
  const [movie, setMovie] = useState(null)
  const [error, setError] = useState('')

  useEffect(() => {
    getMovie(id)
      .then(setMovie)
      .catch((e) => setError(e.message))
  }, [id])

  async function handleDelete() {
    if (!window.confirm(`Видалити фільм «${movie.title}»?`)) return
    await deleteMovie(id)
    navigate('/')
  }

  if (error) return <p className="message error">{error}</p>
  if (!movie) return <p className="message">Завантаження...</p>

  return (
    <div className="movie-details">
      <img src={posterUrl(movie.posterPath)} alt={movie.title} className="details-poster" />
      <div className="details-info">
        <h2>{movie.title} <small>({movie.releaseYear})</small></h2>
        <p><strong>Рік випуску:</strong> {movie.releaseYear}</p>
        <p><strong>Режисер:</strong> {movie.director}</p>
        <p><strong>Жанр:</strong> {movie.genre}</p>
        <hr />
        <p>{movie.description}</p>

        <div className="actions">
          <Link to={`/edit/${movie.id}`} className="btn btn-primary">Редагувати</Link>
          <button onClick={handleDelete} className="btn btn-danger">Видалити</button>
          <Link to="/" className="btn btn-link">← Назад до списку</Link>
        </div>
      </div>
    </div>
  )
}
