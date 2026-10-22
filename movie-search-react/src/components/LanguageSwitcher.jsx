import { useTranslation } from 'react-i18next'

const LANGS = [
  { code: 'uk', label: 'Українська' },
  { code: 'en', label: 'English' },
  { code: 'fr', label: 'Français' },
]

export default function LanguageSwitcher() {
  const { i18n, t } = useTranslation()

  return (
    <select
      className="lang-switcher"
      aria-label={t('header.language')}
      value={i18n.resolvedLanguage}
      onChange={(e) => i18n.changeLanguage(e.target.value)}
    >
      {LANGS.map((l) => (
        <option key={l.code} value={l.code}>{l.label}</option>
      ))}
    </select>
  )
}
