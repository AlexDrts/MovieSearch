import { useEffect } from 'react'
import { Link, Route, Routes } from 'react-router-dom'
import { useTranslation } from 'react-i18next'
import LanguageSwitcher from './components/LanguageSwitcher.jsx'
import MovieList from './pages/MovieList.jsx'
import MovieDetails from './pages/MovieDetails.jsx'
import MovieForm from './pages/MovieForm.jsx'
import NotFound from './pages/NotFound.jsx'

export default function App() {
  const { t, i18n } = useTranslation()

  useEffect(() => {
    document.documentElement.lang = i18n.resolvedLanguage
    document.title = t('header.title').replace('🎬 ', '')
  }, [i18n.resolvedLanguage, t])

  return (
    <>
      <header className="header">
        <div className="container header-inner">
          <Link to="/" className="logo">{t('header.title')}</Link>
          <div className="header-actions">
            <LanguageSwitcher />
            <Link to="/create" className="btn btn-success">{t('header.addMovie')}</Link>
          </div>
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
