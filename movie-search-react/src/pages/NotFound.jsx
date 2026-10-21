import { Link } from 'react-router-dom'

export default function NotFound() {
  return (
    <div className="not-found">
      <h1>404</h1>
      <h3>Сторінку не знайдено</h3>
      <Link to="/" className="btn btn-primary">На головну</Link>
    </div>
  )
}
