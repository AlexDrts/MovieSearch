import { Link } from 'react-router-dom'
import { useTranslation } from 'react-i18next'

export default function NotFound() {
  const { t } = useTranslation()

  return (
    <div className="not-found">
      <h1>404</h1>
      <h3>{t('notFound.title')}</h3>
      <Link to="/" className="btn btn-primary">{t('common.home')}</Link>
    </div>
  )
}
