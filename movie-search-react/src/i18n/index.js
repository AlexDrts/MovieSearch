import i18n from 'i18next'
import { initReactI18next } from 'react-i18next'
import LanguageDetector from 'i18next-browser-languagedetector'

import uk from '../locales/uk/translation.json'
import en from '../locales/en/translation.json'
import fr from '../locales/fr/translation.json'

i18n
  .use(LanguageDetector)
  .use(initReactI18next)
  .init({
    resources: {
      uk: { translation: uk },
      en: { translation: en },
      fr: { translation: fr },
    },
    fallbackLng: 'uk',
    supportedLngs: ['uk', 'en', 'fr'],
    nonExplicitSupportedLngs: true,
    interpolation: {
      escapeValue: false,
    },
    detection: {
      order: ['querystring', 'localStorage', 'navigator'],
      lookupQuerystring: 'lng',
      caches: ['localStorage'],
    },
  })

export default i18n
