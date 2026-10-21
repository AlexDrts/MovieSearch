import { useEffect, useState } from 'react'
import { Link, useNavigate, useParams } from 'react-router-dom'
import { createMovie, getMovie, updateMovie, uploadPoster } from '../api.js'

const emptyMovie = {
  title: '',
  director: '',
  genre: '',
  releaseYear: '',
  description: '',
  posterPath: '',
}

const allowedExtensions = ['.jpg', '.jpeg', '.png', '.webp', '.gif']

const fields = [
  { name: 'title', label: 'Назва' },
  { name: 'director', label: 'Режисер' },
  { name: 'genre', label: 'Жанр' },
  { name: 'releaseYear', label: 'Рік випуску', type: 'number' },
]

export default function MovieForm() {
  const { id } = useParams()
  const isEdit = Boolean(id)
  const navigate = useNavigate()
  const [movie, setMovie] = useState(emptyMovie)
  const [file, setFile] = useState(null)
  const [errors, setErrors] = useState({})
  const [saving, setSaving] = useState(false)

  useEffect(() => {
    if (!isEdit) return
    getMovie(id).then((data) =>
      setMovie({ ...data, posterPath: data.posterPath || '' }),
    )
  }, [id, isEdit])

  function handleChange(e) {
    setMovie({ ...movie, [e.target.name]: e.target.value })
  }

  async function handleSubmit(e) {
    e.preventDefault()
    setErrors({})

    if (file && !allowedExtensions.some((ext) => file.name.toLowerCase().endsWith(ext))) {
      setErrors({ file: ['Дозволені лише зображення: jpg, jpeg, png, webp, gif'] })
      return
    }

    setSaving(true)

    const data = {
      ...movie,
      releaseYear: movie.releaseYear === '' ? null : Number(movie.releaseYear),
      posterPath: movie.posterPath || null,
    }

    try {
      const saved = isEdit ? await updateMovie(id, data) : await createMovie(data)
      if (file) await uploadPoster(saved.id, file)
      navigate(`/movies/${saved.id}`)
    } catch (err) {
      setErrors(err.errors || {})
      setSaving(false)
    }
  }

  function errorFor(name) {
    const key = Object.keys(errors).find((k) => k.toLowerCase() === name.toLowerCase())
    return key ? errors[key][0] : null
  }

  return (
    <form onSubmit={handleSubmit} className="movie-form">
      <h2>{isEdit ? `Редагувати: ${movie.title}` : 'Додати фільм'}</h2>

      {fields.map((field) => (
        <div key={field.name} className="field">
          <label htmlFor={field.name}>{field.label}</label>
          <input
            id={field.name}
            name={field.name}
            type={field.type || 'text'}
            value={movie[field.name]}
            onChange={handleChange}
          />
          {errorFor(field.name) && <span className="field-error">{errorFor(field.name)}</span>}
        </div>
      ))}

      <div className="field">
        <label htmlFor="description">Опис</label>
        <textarea id="description" name="description" rows="4" value={movie.description} onChange={handleChange} />
        {errorFor('description') && <span className="field-error">{errorFor('description')}</span>}
      </div>

      <div className="field">
        <label htmlFor="posterFile">Постер (файл з пристрою)</label>
        <input
          id="posterFile"
          type="file"
          accept={allowedExtensions.join(',')}
          onChange={(e) => setFile(e.target.files[0] || null)}
        />
        {errorFor('file') && <span className="field-error">{errorFor('file')}</span>}
      </div>

      <div className="field">
        <label htmlFor="posterPath">або посилання на постер (URL)</label>
        <input id="posterPath" name="posterPath" value={movie.posterPath} onChange={handleChange} />
      </div>

      <div className="actions">
        <button type="submit" className="btn btn-success" disabled={saving}>
          {saving ? 'Збереження...' : 'Зберегти'}
        </button>
        <Link to={isEdit ? `/movies/${id}` : '/'} className="btn btn-secondary">Скасувати</Link>
      </div>
    </form>
  )
}
