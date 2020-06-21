import { connect } from 'react-redux';
import { ComicSearchForm } from './ComicSearchForm';
import {
  updateTitleInput,
  updateIssueNumberInput,
  updateResultsFromForm
} from './comicSearchFormActions';
import {
  toggleLoading,
  setSelectedComic
} from '../ComicResults/comicResultsActions';
import { makeSaveComicRequest } from '../SavedComics/savedComicsActions';

const mapStateToProps = ({ comicSearchForm, comicResults }) => ({
  ...comicSearchForm,
  ...comicResults
});

const mapDispatchToProps = dispatch => ({
  updateTitleInput: title => dispatch(updateTitleInput(title)),
  updateIssueNumberInput: issueNumber =>
    dispatch(updateIssueNumberInput(issueNumber)),
  updateResultsFromForm: dispatch(updateResultsFromForm),
  toggleComicSearchLoadingTrue: () => dispatch(toggleLoading(true)),
  setSelectedComic: comic => dispatch(setSelectedComic(comic)),
  makeSaveComicRequest: selectedComic =>
    dispatch(makeSaveComicRequest(selectedComic))
});

export const ComicSearchFormContainer = connect(
  mapStateToProps,
  mapDispatchToProps
)(ComicSearchForm);
