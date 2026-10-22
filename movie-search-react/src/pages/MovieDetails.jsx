import { useEffect, useState } from 'react'
import { Link, useNavigate, useParams } from 'react-router-dom'
import { useTranslation } from 'react-i18next'
import { deleteMovie, getMovie, posterUrl } from '../api.js'

export default function MovieDetails() {
  const { t } = useTranslation()
  const { id } = useParams()
  const navigate = useNavigate()
  const [movie, setMovie] = useState(null)
  const [error, setError] = useState(false)

  useEffect(() => {
    getMovie(id)
      .then(setMovie)
      .catch(() => setError(true))
  }, [id])

  async function handleDelete() {
    if (!window.confirm(t('details.confirmDelete', { title: movie.title }))) return
    await deleteMovie(id)
    navigate('/')
  }

  if (error) return <p className="message error">{t('details.notFound')}</p>
  if (!movie) return <p className="message">{t('common.loading')}</p>

  return (
    <div className="movie-details">
      <img src={posterUrl(movie.posterPath)} alt={movie.title} className="details-poster" />
      <div className="details-info">
        <h2>{movie.title} <small>({movie.releaseYear})</small></h2>
        <p><strong>{t('details.releaseYear')}</strong> {movie.releaseYear}</p>
        <p><strong>{t('details.director')}</strong> {movie.director}</p>
        <p><strong>{t('details.genre')}</strong> {movie.genre}</p>
        <hr />
        <p>{movie.description}</p>

        <div className="actions">
          <Link to={`/edit/${movie.id}`} className="btn btn-primary">{t('common.edit')}</Link>
          <button onClick={handleDelete} className="btn btn-danger">{t('common.delete')}</button>
          <Link to="/" className="btn btn-link">{t('common.backToList')}</Link>
        </div>
      </div>
    </div>
  )
}
