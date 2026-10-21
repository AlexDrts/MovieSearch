const API_URL = (import.meta.env.VITE_API_URL || 'http://localhost:5074').replace(/\/$/, '')

async function request(path, options) {
  const response = await fetch(API_URL + path, options)

  if (response.status === 204) return null

  const data = await response.json().catch(() => null)

  if (!response.ok) {
    const error = new Error(response.status === 404 ? 'Фільм не знайдено' : 'Помилка запиту')
    error.status = response.status
    error.errors = data?.errors || {}
    throw error
  }

  return data
}

function sendJson(method, path, movie) {
  return request(path, {
    method,
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(movie),
  })
}

export const getMovies = () => request('/api/movies')

export const getMovie = (id) => request(`/api/movies/${id}`)

export const createMovie = (movie) => sendJson('POST', '/api/movies', movie)

export const updateMovie = (id, movie) => sendJson('PUT', `/api/movies/${id}`, movie)

export const deleteMovie = (id) => request(`/api/movies/${id}`, { method: 'DELETE' })

export function uploadPoster(id, file) {
  const form = new FormData()
  form.append('File', file)
  return request(`/api/movies/${id}/poster`, { method: 'POST', body: form })
}

export function posterUrl(path) {
  if (!path) return null
  return path.startsWith('/') ? API_URL + path : path
}
