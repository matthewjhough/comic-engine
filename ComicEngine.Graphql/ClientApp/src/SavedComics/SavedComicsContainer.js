import { connect } from 'react-redux';
import { toggleLoading, setResults } from '../ComicResults/comicResultsActions';
import { getSavedComics } from './savedComicsActions';
import { SavedComics } from './SavedComics';

const mapStateToProps = ({ comicResults }) => ({ ...comicResults });

const mapDispatchToProps = dispatch => ({
  toggleLoading: isLoading => dispatch(toggleLoading(isLoading)),
  getSavedComics: () => dispatch(getSavedComics()),
  clearResults: () => dispatch(setResults([]))
});

export const SavedComicsContainer = connect(
  mapStateToProps,
  mapDispatchToProps
)(SavedComics);
